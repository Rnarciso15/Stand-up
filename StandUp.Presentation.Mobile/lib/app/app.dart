import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import '../core/theme/glass_theme.dart';
import '../presentation/appointments/appointments_page.dart';
import '../presentation/auth/login_page.dart';
import '../presentation/clients/clients_page.dart';
import '../presentation/dashboard/dashboard_page.dart';
import '../presentation/sales/sales_page.dart';
import '../presentation/vehicles/vehicles_page.dart';

class StandUpApp extends ConsumerWidget {
  const StandUpApp({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final router = GoRouter(
      initialLocation: '/login',
      routes: [
        GoRoute(path: '/login', builder: (context, state) => const LoginPage()),
        GoRoute(path: '/dashboard', builder: (context, state) => const DashboardPage()),
        GoRoute(path: '/appointments', builder: (context, state) => const AppointmentsPage()),
        GoRoute(path: '/vehicles', builder: (context, state) => const VehiclesPage()),
        GoRoute(path: '/sales', builder: (context, state) => const SalesPage()),
        GoRoute(path: '/clients', builder: (context, state) => const ClientsPage()),
      ],
    );

    return MaterialApp.router(
      title: 'StandUp Mobile',
      debugShowCheckedModeBanner: false,
      theme: GlassTheme.theme(),
      routerConfig: router,
    );
  }
}
