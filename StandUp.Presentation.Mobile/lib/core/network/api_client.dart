import 'package:dio/dio.dart';
import '../config/app_config.dart';
import '../storage/session_storage.dart';

class ApiClient {
  ApiClient(this._sessionStorage)
      : _dio = Dio(BaseOptions(
          baseUrl: AppConfig.apiBaseUrl,
          connectTimeout: const Duration(seconds: 12),
          receiveTimeout: const Duration(seconds: 12),
          headers: {'Content-Type': 'application/json'},
        )) {
    _dio.interceptors.add(InterceptorsWrapper(onRequest: (options, handler) async {
      final role = await _sessionStorage.role();
      if (role != null && role.isNotEmpty) {
        options.headers['X-User-Role'] = role;
      }
      handler.next(options);
    }));
  }

  final SessionStorage _sessionStorage;
  final Dio _dio;

  Dio get dio => _dio;
}
