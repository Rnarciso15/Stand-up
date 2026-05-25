import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class SessionStorage {
  static const _tokenKey = 'session_token';
  static const _roleKey = 'session_role';
  static const _nameKey = 'session_name';

  final FlutterSecureStorage _storage = const FlutterSecureStorage();

  Future<void> saveSession({required String token, required String role, required String name}) async {
    await _storage.write(key: _tokenKey, value: token);
    await _storage.write(key: _roleKey, value: role);
    await _storage.write(key: _nameKey, value: name);
  }

  Future<String?> token() => _storage.read(key: _tokenKey);
  Future<String?> role() => _storage.read(key: _roleKey);
  Future<String?> name() => _storage.read(key: _nameKey);

  Future<void> clear() async {
    await _storage.delete(key: _tokenKey);
    await _storage.delete(key: _roleKey);
    await _storage.delete(key: _nameKey);
  }
}
