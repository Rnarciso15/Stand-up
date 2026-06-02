// Stand Up — utilitários JS (localStorage, share, theme, search)
window.su = {
    favorites: {
        get()         { return JSON.parse(localStorage.getItem('su_favorites') || '[]'); },
        add(plate)    { const l = this.get(); if (!l.includes(plate)) { l.push(plate); localStorage.setItem('su_favorites', JSON.stringify(l)); } return l; },
        remove(plate) { const l = this.get().filter(p => p !== plate); localStorage.setItem('su_favorites', JSON.stringify(l)); return l; },
        has(plate)    { return this.get().includes(plate); },
        count()       { return this.get().length; }
    },
    recent: {
        get()      { return JSON.parse(localStorage.getItem('su_recent') || '[]'); },
        add(plate) { let l = this.get().filter(p => p !== plate); l.unshift(plate); if (l.length > 6) l = l.slice(0, 6); localStorage.setItem('su_recent', JSON.stringify(l)); }
    },
    theme: {
        init()   { const s = localStorage.getItem('su_theme') || 'dark'; document.documentElement.setAttribute('data-theme', s); return s; },
        toggle() { const c = document.documentElement.getAttribute('data-theme') || 'dark'; const n = c === 'dark' ? 'light' : 'dark'; document.documentElement.setAttribute('data-theme', n); localStorage.setItem('su_theme', n); return n; },
        get()    { return document.documentElement.getAttribute('data-theme') || 'dark'; }
    },
    search: {
        _vehicles: null,
        _loading: false,

        async _load() {
            if (this._vehicles !== null || this._loading) return;
            this._loading = true;
            try {
                const r = await fetch('/_search/vehicles');
                this._vehicles = await r.json();
            } catch { this._vehicles = []; }
            this._loading = false;
        },

        _filter(q) {
            if (!this._vehicles || q.length < 2) return [];
            const lq = q.toLowerCase();
            return this._vehicles
                .filter(v => (v.brand || '').toLowerCase().includes(lq) ||
                             (v.model || '').toLowerCase().includes(lq) ||
                             (v.licensePlate || '').toLowerCase().includes(lq))
                .slice(0, 6);
        },

        _fmt(n) { return Number(n).toLocaleString('pt-PT'); },

        _render(results, q, container) {
            if (!results.length) { container.innerHTML = ''; return; }
            const items = results.map(v => `
<a class="su-search-option" href="/veiculos/${encodeURIComponent(v.licensePlate)}">
  <div class="su-search-option-info">
    <div class="su-search-option-brand">${v.brand}</div>
    <div class="su-search-option-model">${v.model}</div>
    <div class="su-search-option-plate">${v.licensePlate}</div>
  </div>
  <div class="su-search-option-price">€${this._fmt(v.price)}</div>
</a>`).join('');
            const footer = `<a class="su-search-option-all" href="/veiculos?q=${encodeURIComponent(q)}">Ver todos os resultados <span class="su-search-option-all-arrow">→</span></a>`;
            container.innerHTML = `<div class="su-search-dropdown">${items}${footer}</div>`;
        },

        init() {
            const input = document.getElementById('su-global-search');
            const container = document.getElementById('su-search-dropdown-container');
            const form = input && input.closest('form');
            if (!input || !container) return;

            input.addEventListener('input', async () => {
                const q = input.value.trim();
                await su.search._load();
                su.search._render(su.search._filter(q), q, container);
            });

            input.addEventListener('blur', () => {
                setTimeout(() => { container.innerHTML = ''; }, 200);
            });

            if (form) {
                form.addEventListener('submit', e => {
                    e.preventDefault();
                    const q = input.value.trim();
                    container.innerHTML = '';
                    if (q) window.location.href = '/veiculos?q=' + encodeURIComponent(q);
                });
            }
        }
    },
    async share(title, url) {
        if (navigator.share) { try { await navigator.share({ title, url }); return 'native'; } catch {} }
        try { await navigator.clipboard.writeText(url); return 'clipboard'; } catch {}
        return 'failed';
    }
};

// Inicialização ao carregar
su.theme.init();
su.search.init();

// Re-aplicar tema e pesquisa após cada navegação Blazor (enhanced navigation)
document.addEventListener('enhancedload', () => {
    su.theme.init();
    su.search.init();
});
