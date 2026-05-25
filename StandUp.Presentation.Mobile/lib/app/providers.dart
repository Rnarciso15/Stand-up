import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../core/network/api_client.dart';
import '../core/storage/session_storage.dart';
import '../data/repositories/standup_repository.dart';

final sessionStorageProvider = Provider<SessionStorage>((ref) => SessionStorage());
final apiClientProvider = Provider<ApiClient>((ref) => ApiClient(ref.read(sessionStorageProvider)));
final repositoryProvider = Provider<StandUpRepository>((ref) => StandUpRepository(ref.read(apiClientProvider)));

final roleProvider = StateProvider<String>((ref) => 'Rececao');
final nameProvider = StateProvider<String>((ref) => '');
