import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../../app/providers.dart';
import '../../core/theme/glass_theme.dart';
import '../shared/glass_scaffold.dart';

class SalesPage extends ConsumerStatefulWidget {
  const SalesPage({super.key});

  @override
  ConsumerState<SalesPage> createState() => _SalesPageState();
}

class _SalesPageState extends ConsumerState<SalesPage> {
  bool _loading = true;
  List<dynamic> _sales = [];
  String? _message;

  @override
  void initState() {
    super.initState();
    _load();
  }

  @override
  Widget build(BuildContext context) {
    return GlassScaffold(
      title: 'Vendas e Propostas',
      body: Column(
        children: [
          if (_message != null) Padding(padding: const EdgeInsets.only(bottom: 8), child: Text(_message!)),
          Expanded(
            child: _loading
                ? const Center(child: CircularProgressIndicator())
                : ListView.separated(
                    itemCount: _sales.length,
                    separatorBuilder: (_, __) => const SizedBox(height: 8),
                    itemBuilder: (context, i) {
                      final s = _sales[i];
                      return GlassCard(
                        child: Row(
                          children: [
                            const Icon(Icons.receipt_long, color: Color(0xFF9AD1FF)),
                            const SizedBox(width: 10),
                            Expanded(child: Text('${s.clientName} - ${s.licensePlate}')),
                            FilledButton(
                              onPressed: () => _generate(s.id as int),
                              child: const Text('Gerar PDF'),
                            )
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

  Future<void> _load() async {
    final data = await ref.read(repositoryProvider).sales();
    if (mounted) {
      setState(() {
        _sales = data;
        _loading = false;
      });
    }
  }

  Future<void> _generate(int saleId) async {
    await ref.read(repositoryProvider).generateProposal(saleId, DateTime.now().toUtc().add(const Duration(days: 7)));
    if (mounted) setState(() => _message = 'Proposta gerada para venda #$saleId');
  }
}
