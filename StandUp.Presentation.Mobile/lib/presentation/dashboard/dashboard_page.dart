import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../../app/providers.dart';
import '../../core/theme/glass_theme.dart';
import '../shared/glass_scaffold.dart';

class DashboardPage extends ConsumerStatefulWidget {
  const DashboardPage({super.key});

  @override
  ConsumerState<DashboardPage> createState() => _DashboardPageState();
}

class _DashboardPageState extends ConsumerState<DashboardPage> {
  bool _loading = true;
  String? _error;
  int appointments = 0;
  int sales = 0;
  num conversion = 0;

  @override
  void initState() {
    super.initState();
    _load();
  }

  @override
  Widget build(BuildContext context) {
    final userName = ref.watch(nameProvider);
    return GlassScaffold(
      title: 'Dashboard',
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text('Bem-vindo, $userName', style: Theme.of(context).textTheme.headlineSmall),
          const SizedBox(height: 16),
          if (_loading) const Center(child: CircularProgressIndicator()),
          if (_error != null) Text(_error!, style: const TextStyle(color: Colors.redAccent)),
          if (!_loading && _error == null)
            AnimatedSwitcher(
              duration: const Duration(milliseconds: 350),
              child: Wrap(
                key: ValueKey('$appointments-$sales-$conversion'),
                spacing: 12,
                runSpacing: 12,
                children: [
                  _kpi('Marcacoes', '$appointments', Icons.event),
                  _kpi('Vendas', '$sales', Icons.sell),
                  _kpi('Conversao', '${conversion.toStringAsFixed(1)}%', Icons.percent),
                ],
              ),
            ),
        ],
      ),
    );
  }

  Widget _kpi(String title, String value, IconData icon) {
    return SizedBox(
      width: 180,
      child: GlassCard(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Icon(icon, color: const Color(0xFF9AD1FF)),
            const SizedBox(height: 8),
            Text(title),
            const SizedBox(height: 8),
            Text(value, style: const TextStyle(fontSize: 28, fontWeight: FontWeight.bold)),
          ],
        ),
      ),
    );
  }

  Future<void> _load() async {
    try {
      final repo = ref.read(repositoryProvider);
      final now = DateTime.now().toUtc();
      final kpi = await repo.dashboard(now.subtract(const Duration(days: 30)), now);
      setState(() {
        appointments = kpi.totalAppointments;
        sales = kpi.totalSales;
        conversion = kpi.conversionRate;
      });
    } catch (e) {
      setState(() => _error = 'Erro ao carregar dashboard: $e');
    } finally {
      if (mounted) setState(() => _loading = false);
    }
  }
}
