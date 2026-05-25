class LoginResultModel {
  final bool isAuthenticated;
  final String? name;
  final String? role;

  LoginResultModel({required this.isAuthenticated, this.name, this.role});

  factory LoginResultModel.fromJson(Map<String, dynamic> json) => LoginResultModel(
        isAuthenticated: json['isAuthenticated'] == true,
        name: json['name'] as String?,
        role: json['role'] as String?,
      );
}

class DashboardKpiModel {
  final int totalAppointments;
  final int totalSales;
  final num conversionRate;

  DashboardKpiModel({required this.totalAppointments, required this.totalSales, required this.conversionRate});

  factory DashboardKpiModel.fromJson(Map<String, dynamic> json) => DashboardKpiModel(
        totalAppointments: (json['totalAppointments'] ?? 0) as int,
        totalSales: (json['totalSales'] ?? 0) as int,
        conversionRate: (json['conversionRate'] ?? 0) as num,
      );
}

class AppointmentModel {
  final int id;
  final String clientName;
  final String vehicleLabel;
  final DateTime dateTimeSlot;

  AppointmentModel({required this.id, required this.clientName, required this.vehicleLabel, required this.dateTimeSlot});

  factory AppointmentModel.fromJson(Map<String, dynamic> json) => AppointmentModel(
        id: json['id'] as int,
        clientName: (json['clientName'] ?? '') as String,
        vehicleLabel: '${json['vehicleBrand'] ?? ''} ${json['vehicleModel'] ?? ''}'.trim(),
        dateTimeSlot: DateTime.parse(json['dateTimeSlot'] as String),
      );
}

class VehicleModel {
  final String licensePlate;
  final String brand;
  final String model;
  final int price;

  VehicleModel({required this.licensePlate, required this.brand, required this.model, required this.price});

  factory VehicleModel.fromJson(Map<String, dynamic> json) => VehicleModel(
        licensePlate: (json['licensePlate'] ?? '') as String,
        brand: (json['brand'] ?? '') as String,
        model: (json['model'] ?? '') as String,
        price: (json['price'] ?? 0) as int,
      );
}

class SaleModel {
  final int id;
  final String clientName;
  final String licensePlate;

  SaleModel({required this.id, required this.clientName, required this.licensePlate});

  factory SaleModel.fromJson(Map<String, dynamic> json) => SaleModel(
        id: json['id'] as int,
        clientName: (json['clientName'] ?? '') as String,
        licensePlate: (json['vehicleLicensePlate'] ?? '') as String,
      );
}

class ClientModel {
  final int id;
  final String name;
  final String? phone;

  ClientModel({required this.id, required this.name, this.phone});

  factory ClientModel.fromJson(Map<String, dynamic> json) => ClientModel(
        id: json['id'] as int,
        name: (json['name'] ?? '') as String,
        phone: json['phone'] as String?,
      );
}
