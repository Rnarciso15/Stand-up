import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import '../../core/theme/glass_theme.dart';

class GlassScaffold extends StatelessWidget {
  const GlassScaffold({
    super.key,
    required this.title,
    required this.body,
    this.actions = const [],
    this.showQuickNav = true,
  });
  final String title;
  final Widget body;
  final List<Widget> actions;
  final bool showQuickNav;

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(gradient: GlassTheme.backgroundGradient),
      child: Scaffold(
        backgroundColor: Colors.transparent,
        appBar: AppBar(
          title: Text(title),
          backgroundColor: Colors.transparent,
          elevation: 0,
          actions: actions,
        ),
        body: SafeArea(
          child: Column(
            children: [
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.all(16),
                  child: body,
                ),
              ),
              if (showQuickNav) const _QuickNav(),
              const SizedBox(height: 12),
            ],
          ),
        ),
      ),
    );
  }
}

class _QuickNav extends StatelessWidget {
  const _QuickNav();

  @override
  Widget build(BuildContext context) {
    final location = GoRouterState.of(context).uri.path;
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 16),
      child: GlassCard(
        padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 8),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            _navItem(context, location, '/dashboard', Icons.dashboard_rounded),
            _navItem(context, location, '/appointments', Icons.event),
            _navItem(context, location, '/vehicles', Icons.directions_car),
            _navItem(context, location, '/sales', Icons.receipt_long),
            _navItem(context, location, '/clients', Icons.people),
          ],
        ),
      ),
    );
  }

  Widget _navItem(BuildContext context, String location, String route, IconData icon) {
    final selected = location == route;
    return IconButton(
      onPressed: () => context.go(route),
      icon: Icon(icon, color: selected ? const Color(0xFF9AD1FF) : Colors.white70),
    );
  }
}
