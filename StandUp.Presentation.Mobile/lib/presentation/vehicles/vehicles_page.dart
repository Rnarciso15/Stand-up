import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../../app/providers.dart';
import '../../core/theme/glass_theme.dart';
import '../shared/glass_scaffold.dart';

class VehiclesPage extends ConsumerStatefulWidget {
  const VehiclesPage({super.key});

  @override
  ConsumerState<VehiclesPage> createState() => _VehiclesPageState();
}

class _VehiclesPageState extends ConsumerState<VehiclesPage> {
  final _brandCtrl = TextEditingController();
  bool _loading = false;
  List<dynamic> _vehicles = [];

  @override
  Widget build(BuildContext context) {
    return GlassScaffold(
      title: 'Pesquisa Veiculos',
      body: Column(
        children: [
          GlassCard(
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: _brandCtrl,
                    decoration: const InputDecoration(labelText: 'Marca'),
                  ),
                ),
                const SizedBox(width: 12),
                FilledButton(onPressed: _loading ? null : _search, child: const Text('Pesquisar')),
              ],
            ),
          ),
          const SizedBox(height: 12),
          Expanded(
            child: _loading
                ? const Center(child: CircularProgressIndicator())
                : ListView.separated(
                    itemCount: _vehicles.length,
                    separatorBuilder: (_, __) => const SizedBox(height: 8),
                    itemBuilder: (context, i) {
                      final v = _vehicles[i];
                      return GlassCard(
                        child: Row(
                          children: [
                            const Icon(Icons.directions_car, color: Color(0xFF9AD1FF)),
                            const SizedBox(width: 10),
                            Expanded(child: Text('${v.brand} ${v.model} (${v.licensePlate})')),
                            Text('${v.price} EUR', style: const TextStyle(fontWeight: FontWeight.w700)),
                          ],
                        ),
                      );
                    },
                  ),
          )
        ],
      ),
    );
  }

  Future<void> _search() async {
    setState(() => _loading = true);
    final data = await ref.read(repositoryProvider).searchVehicles(brand: _brandCtrl.text.trim(), page: 1, pageSize: 20);
    if (mounted) {
      setState(() {
        _vehicles = data;
        _loading = false;
      });
    }
  }
}
