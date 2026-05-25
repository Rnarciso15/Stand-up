import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../../app/providers.dart';
import '../../core/theme/glass_theme.dart';
import '../shared/glass_scaffold.dart';

class AppointmentsPage extends ConsumerStatefulWidget {
  const AppointmentsPage({super.key});

  @override
  ConsumerState<AppointmentsPage> createState() => _AppointmentsPageState();
}

class _AppointmentsPageState extends ConsumerState<AppointmentsPage> {
  bool _loading = true;
  String? _message;
  List<dynamic> _items = [];

  @override
  void initState() {
    super.initState();
    _load();
  }

  @override
  Widget build(BuildContext context) {
    return GlassScaffold(
      title: 'Marcacoes',
      body: Column(
        children: [
          if (_message != null) Padding(padding: const EdgeInsets.only(bottom: 8), child: Text(_message!)),
          Expanded(
            child: _loading
                ? const Center(child: CircularProgressIndicator())
                : ListView.separated(
                    itemCount: _items.length,
                    separatorBuilder: (_, __) => const SizedBox(height: 8),
                    itemBuilder: (context, i) {
                      final a = _items[i];
                      return TweenAnimationBuilder<double>(
                        duration: Duration(milliseconds: 200 + (i * 60)),
                        tween: Tween(begin: 0, end: 1),
                        builder: (context, value, child) => Opacity(opacity: value, child: Transform.translate(offset: Offset(0, 12 * (1 - value)), child: child)),
                        child: GlassCard(
                          child: Row(
                            children: [
                              Expanded(child: Text('${a.clientName} - ${a.vehicleLabel}')),
                              IconButton(
                                onPressed: () => _sendReminder(a.id as int),
                                icon: const Icon(Icons.sms),
                              )
                            ],
                          ),
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
    final data = await ref.read(repositoryProvider).appointments(DateTime.now().toUtc());
    if (mounted) {
      setState(() {
        _items = data;
        _loading = false;
      });
    }
  }

  Future<void> _sendReminder(int id) async {
    await ref.read(repositoryProvider).sendReminder(id);
    if (mounted) {
      setState(() => _message = 'Lembrete enviado para marcacao #$id');
    }
  }
}
