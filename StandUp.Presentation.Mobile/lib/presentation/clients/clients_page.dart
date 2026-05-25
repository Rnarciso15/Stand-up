import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../../app/providers.dart';
import '../../core/theme/glass_theme.dart';
import '../shared/glass_scaffold.dart';

class ClientsPage extends ConsumerStatefulWidget {
  const ClientsPage({super.key});

  @override
  ConsumerState<ClientsPage> createState() => _ClientsPageState();
}

class _ClientsPageState extends ConsumerState<ClientsPage> {
  bool _loading = true;
  List<dynamic> _clients = [];

  @override
  void initState() {
    super.initState();
    _load();
  }

  @override
  Widget build(BuildContext context) {
    return GlassScaffold(
      title: 'Clientes',
      body: _loading
          ? const Center(child: CircularProgressIndicator())
          : ListView.separated(
              itemCount: _clients.length,
              separatorBuilder: (_, __) => const SizedBox(height: 8),
              itemBuilder: (context, i) {
                final c = _clients[i];
                return GlassCard(
                  child: Row(
                    children: [
                      const Icon(Icons.person, color: Color(0xFF9AD1FF)),
                      const SizedBox(width: 10),
                      Expanded(child: Text(c.name as String)),
                      Text((c.phone ?? '') as String),
                    ],
                  ),
                );
              },
            ),
    );
  }

  Future<void> _load() async {
    final data = await ref.read(repositoryProvider).clients();
    if (mounted) {
      setState(() {
        _clients = data;
        _loading = false;
      });
    }
  }
}
