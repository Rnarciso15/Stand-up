import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import '../../app/providers.dart';
import '../../core/theme/glass_theme.dart';
import '../shared/glass_scaffold.dart';

class LoginPage extends ConsumerStatefulWidget {
  const LoginPage({super.key});

  @override
  ConsumerState<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends ConsumerState<LoginPage> {
  final _employeeCtrl = TextEditingController(text: '1000');
  final _passwordCtrl = TextEditingController(text: 'teste');
  bool _loading = false;
  String? _error;

  @override
  Widget build(BuildContext context) {
    return GlassScaffold(
      title: 'Login',
      showQuickNav: false,
      body: Center(
        child: ConstrainedBox(
          constraints: const BoxConstraints(maxWidth: 420),
          child: GlassCard(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                TextField(
                  controller: _employeeCtrl,
                  keyboardType: TextInputType.number,
                  decoration: const InputDecoration(labelText: 'Numero de funcionario'),
                ),
                const SizedBox(height: 12),
                TextField(
                  controller: _passwordCtrl,
                  obscureText: true,
                  decoration: const InputDecoration(labelText: 'Password'),
                ),
                const SizedBox(height: 16),
                if (_error != null) Text(_error!, style: const TextStyle(color: Colors.redAccent)),
                const SizedBox(height: 8),
                TweenAnimationBuilder<double>(
                  tween: Tween(begin: 0.9, end: 1),
                  duration: const Duration(milliseconds: 450),
                  curve: Curves.easeOutCubic,
                  builder: (context, value, child) => Transform.scale(scale: value, child: child),
                  child: SizedBox(
                    width: double.infinity,
                    child: FilledButton(
                      onPressed: _loading ? null : _login,
                      child: _loading ? const CircularProgressIndicator() : const Text('Entrar'),
                    ),
                  ),
                )
              ],
            ),
          ),
        ),
      ),
    );
  }

  Future<void> _login() async {
    setState(() {
      _loading = true;
      _error = null;
    });
    try {
      final repo = ref.read(repositoryProvider);
      final result = await repo.login(int.parse(_employeeCtrl.text), _passwordCtrl.text);
      if (!result.isAuthenticated) {
        setState(() => _error = 'Credenciais invalidas');
        return;
      }
      final role = result.role ?? 'Rececao';
      final name = result.name ?? 'Utilizador';
      ref.read(roleProvider.notifier).state = role;
      ref.read(nameProvider.notifier).state = name;
      await ref.read(sessionStorageProvider).saveSession(token: 'local-session', role: role, name: name);
      if (mounted) context.go('/dashboard');
    } catch (e) {
      setState(() => _error = 'Erro: $e');
    } finally {
      if (mounted) setState(() => _loading = false);
    }
  }
}
