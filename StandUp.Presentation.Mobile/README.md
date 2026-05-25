# StandUp Mobile (Flutter + Glassmorphism)

## Setup
1. Install Flutter SDK.
2. Run `flutter pub get`.
3. Start API backend (`StandUp.Presentation.Api`).
4. Run app:
   - Android emulator/device: `flutter run --dart-define=API_BASE_URL=http://10.0.2.2:5000`
   - iOS simulator: `flutter run --dart-define=API_BASE_URL=http://localhost:5000`

## Notes
- API role header used: `X-User-Role`.
- Session is persisted in secure storage.
- Glassmorphism design tokens live in `lib/core/theme`.
