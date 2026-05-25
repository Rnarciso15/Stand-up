import 'package:dio/dio.dart';
import '../../core/network/api_client.dart';
import '../../domain/models/models.dart';

class StandUpRepository {
  StandUpRepository(this._apiClient);
  final ApiClient _apiClient;

  Future<LoginResultModel> login(int employeeNumber, String password) async {
    final res = await _apiClient.dio.post('/api/auth/login', data: {'employeeNumber': employeeNumber, 'password': password});
    return LoginResultModel.fromJson(res.data as Map<String, dynamic>);
  }

  Future<DashboardKpiModel> dashboard(DateTime fromUtc, DateTime toUtc) async {
    final res = await _apiClient.dio.get('/api/dashboard/kpis', queryParameters: {'fromUtc': fromUtc.toIso8601String(), 'toUtc': toUtc.toIso8601String()});
    return DashboardKpiModel.fromJson(res.data as Map<String, dynamic>);
  }

  Future<List<AppointmentModel>> appointments(DateTime date) async {
    final res = await _apiClient.dio.get('/api/appointments', queryParameters: {'date': date.toIso8601String()});
    return ((res.data as List).cast<Map<String, dynamic>>()).map(AppointmentModel.fromJson).toList();
  }

  Future<void> sendReminder(int appointmentId, {int hoursBefore = 24}) async {
    await _apiClient.dio.post('/api/notifications/appointments/$appointmentId/reminder', queryParameters: {'hoursBefore': hoursBefore});
  }

  Future<List<VehicleModel>> searchVehicles({String? brand, int page = 1, int pageSize = 20}) async {
    final res = await _apiClient.dio.get('/api/vehicles/search-advanced', queryParameters: {
      if (brand != null && brand.isNotEmpty) 'brand': brand,
      'page': page,
      'pageSize': pageSize,
      'sortBy': 'price'
    });
    return ((res.data as List).cast<Map<String, dynamic>>()).map(VehicleModel.fromJson).toList();
  }

  Future<List<SaleModel>> sales() async {
    final res = await _apiClient.dio.get('/api/sales');
    return ((res.data as List).cast<Map<String, dynamic>>()).map(SaleModel.fromJson).toList();
  }

  Future<void> generateProposal(int saleId, DateTime validUntilUtc) async {
    await _apiClient.dio.post('/api/proposals/$saleId', queryParameters: {'validUntilUtc': validUntilUtc.toIso8601String()});
  }

  Future<Response<dynamic>> downloadProposal(int proposalId) {
    return _apiClient.dio.get('/api/proposals/$proposalId/download', options: Options(responseType: ResponseType.bytes));
  }

  Future<List<ClientModel>> clients() async {
    final res = await _apiClient.dio.get('/api/clients');
    return ((res.data as List).cast<Map<String, dynamic>>()).map(ClientModel.fromJson).toList();
  }
}
