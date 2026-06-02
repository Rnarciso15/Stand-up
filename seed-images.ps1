# ═══════════════════════════════════════════════════════════════════
#  seed-images.ps1
#  Descarrega imagens reais de cada modelo de veículo e carrega-as na API.
#  Fonte: loremflickr.com (fotos reais do Flickr, gratuitas e sem API key)
#
#  Pré-requisito: API a correr em http://localhost:5196
#  Uso: .\seed-images.ps1
# ═══════════════════════════════════════════════════════════════════

param(
    [string]$ApiBase = "http://localhost:5196",
    [int]   $DelayMs = 600,       # pausa entre pedidos (respeitar rate limit)
    [int]   $ImgWidth  = 900,
    [int]   $ImgHeight = 560
)

$headers = @{ "X-User-Role" = "Admin" }
$ErrorActionPreference = "Stop"

# ── Mapeamento marca → palavra-chave para melhor resultado de imagem ──────────
$keywords = @{
    "BMW"            = "BMW,car"
    "Mercedes"       = "Mercedes-Benz,car"
    "Audi"           = "Audi,car"
    "Porsche"        = "Porsche,car"
    "Volkswagen"     = "Volkswagen,car"
    "Toyota"         = "Toyota,car"
    "Ford"           = "Ford,car"
    "Renault"        = "Renault,car"
    "Tesla"          = "Tesla,electric,car"
    "Honda"          = "Honda,car,motorcycle"
    "SEAT"           = "SEAT,car"
    "Cupra"          = "Cupra,car"
    "Peugeot"        = "Peugeot,car"
    "Volvo"          = "Volvo,car"
    "Alfa Romeo"     = "Alfa,Romeo,car"
    "Lamborghini"    = "Lamborghini,supercar"
    "Ferrari"        = "Ferrari,supercar"
    "Maserati"       = "Maserati,car"
    "Land Rover"     = "Land,Rover,SUV"
    "Range Rover"    = "Range,Rover,SUV"
    "Ducati"         = "Ducati,motorcycle"
    "Yamaha"         = "Yamaha,motorcycle"
    "KTM"            = "KTM,motorcycle"
    "Kawasaki"       = "Kawasaki,motorcycle"
    "Aprilia"        = "Aprilia,motorcycle"
    "Triumph"        = "Triumph,motorcycle"
    "Harley-Davidson"= "Harley,Davidson,motorcycle"
    "Mazda"          = "Mazda,car"
    "Nissan"         = "Nissan,car"
    "Kia"            = "Kia,car"
    "Hyundai"        = "Hyundai,car"
    "Opel"           = "Opel,car"
    "Skoda"          = "Skoda,car"
}

function Get-VehicleKeyword([string]$Brand, [string]$Model) {
    $base = if ($keywords.ContainsKey($Brand)) { $keywords[$Brand] } else { "$Brand,car" }
    # Modelos especiais com melhores keywords
    $modelMap = @{
        "911 Carrera S"  = "Porsche,911,car"
        "M3 Competition" = "BMW,M3,car"
        "M5 CS"          = "BMW,M5,car"
        "RS6 Avant"      = "Audi,RS6,car"
        "AMG C63 S"      = "Mercedes,AMG,car"
        "GR Supra"       = "Toyota,Supra,car"
        "Mustang GT"     = "Ford,Mustang,car"
        "Golf R Mk8"     = "Volkswagen,Golf,car"
        "Model S Plaid"  = "Tesla,Model,S,car"
        "Taycan Turbo"   = "Porsche,Taycan,electric"
        "Urus S"         = "Lamborghini,Urus,SUV"
        "SF90 Stradale"  = "Ferrari,SF90,supercar"
        "Panigale V4 S"  = "Ducati,Panigale,motorcycle"
        "S1000RR"        = "BMW,S1000RR,motorcycle"
        "ZX-10RR"        = "Kawasaki,ZX10R,motorcycle"
        "RSV4 Factory"   = "Aprilia,RSV4,motorcycle"
        "Fat Bob"        = "Harley,Davidson,motorcycle"
    }
    foreach ($key in $modelMap.Keys) {
        if ($Model -like "*$key*") { return $modelMap[$key] }
    }
    return $base
}

# ── Verificar se API está acessível ──────────────────────────────────────────
Write-Host "`n🔌 A verificar API em $ApiBase..." -ForegroundColor Cyan
try {
    $ping = Invoke-RestMethod -Uri "$ApiBase/api/vehicles?isSold=false" -Headers $headers -TimeoutSec 5
    Write-Host "   ✓ API acessível — $($ping.Count) veículos encontrados" -ForegroundColor Green
} catch {
    Write-Host "   ✗ API não está a correr. Inicia StandUp.Presentation.Api primeiro." -ForegroundColor Red
    exit 1
}

# ── Buscar todos os veículos ──────────────────────────────────────────────────
$available = Invoke-RestMethod -Uri "$ApiBase/api/vehicles?isSold=false" -Headers $headers
$sold      = Invoke-RestMethod -Uri "$ApiBase/api/vehicles?isSold=true"  -Headers $headers
$vehicles  = $available + $sold

Write-Host "`n🚗 $($vehicles.Count) veículos para processar" -ForegroundColor Cyan

$ok    = 0
$skip  = 0
$fail  = 0
$total = $vehicles.Count
$i     = 0

foreach ($v in $vehicles) {
    $i++
    $plate   = $v.licensePlate
    $brand   = $v.brand
    $model   = $v.model
    $isMoto  = $v.isMotorcycle

    # Verificar se já tem imagem
    try {
        $existing = Invoke-RestMethod -Uri "$ApiBase/api/images/vehicles/$([Uri]::EscapeDataString($plate))" -Headers $headers -ErrorAction SilentlyContinue
        if ($existing -and $existing.Count -gt 0) {
            Write-Host "  [$i/$total] $plate — já tem imagem, a saltar" -ForegroundColor DarkGray
            $skip++
            continue
        }
    } catch { }

    # Determinar keyword da imagem
    $kw = Get-VehicleKeyword $brand $model
    if ($isMoto) {
        # Garantir "motorcycle" para motas
        if ($kw -notlike "*motorcycle*") { $kw = "$kw,motorcycle" }
    }

    # URL de imagem — loremflickr devolve foto real do Flickr correspondente à keyword
    $seed    = [Math]::Abs($plate.GetHashCode()) % 100  # seed para variedade entre modelos
    $imgUrl  = "https://loremflickr.com/$ImgWidth/$ImgHeight/$kw`?lock=$seed"

    Write-Host "  [$i/$total] $plate — $brand $model" -NoNewline -ForegroundColor White
    Write-Host "  →  $imgUrl" -ForegroundColor DarkGray

    try {
        # Descarregar imagem
        $bytes = (Invoke-WebRequest -Uri $imgUrl -UseBasicParsing -TimeoutSec 15).Content

        if ($null -eq $bytes -or $bytes.Length -lt 1000) {
            Write-Host "    ⚠ Imagem demasiado pequena, a saltar" -ForegroundColor Yellow
            $fail++
            continue
        }

        # Converter para base64 (formato esperado pela API: [FromBody] byte[] = JSON base64 string)
        $base64 = [Convert]::ToBase64String($bytes)
        $json   = '"' + $base64 + '"'

        # Upload para a API
        $uploadHeaders = $headers.Clone()
        $uploadHeaders["Content-Type"] = "application/json"

        Invoke-RestMethod `
            -Method Post `
            -Uri "$ApiBase/api/images/vehicles/$([Uri]::EscapeDataString($plate))" `
            -Headers $uploadHeaders `
            -Body $json `
            -TimeoutSec 30 | Out-Null

        $kb = [Math]::Round($bytes.Length / 1024)
        Write-Host "    ✓ Carregada ($kb KB)" -ForegroundColor Green
        $ok++
    }
    catch {
        Write-Host "    ✗ Falhou: $($_.Exception.Message)" -ForegroundColor Red
        $fail++
    }

    # Pausa para não sobrecarregar o loremflickr
    Start-Sleep -Milliseconds $DelayMs
}

# ── Resumo ─────────────────────────────────────────────────────────────────
Write-Host "`n" + ("═" * 55) -ForegroundColor Cyan
Write-Host " Concluído!" -ForegroundColor Green
Write-Host "  ✓ Carregadas com sucesso : $ok" -ForegroundColor Green
Write-Host "  → Já existiam (saltadas) : $skip" -ForegroundColor DarkGray
Write-Host "  ✗ Falhas                 : $fail" -ForegroundColor $(if ($fail -gt 0) { "Yellow" } else { "DarkGray" })
Write-Host ("═" * 55) -ForegroundColor Cyan
