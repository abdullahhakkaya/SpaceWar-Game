# Spacewar Oyunu / Spacewar Game

### Geliştirici / Developed by Abdullah Akkaya  
**Yazılım Mühendisliği, Kocaeli Üniversitesi / Software Engineering, Kocaeli University**  
**Kocaeli/Türkiye / Kocaeli/Turkey**  
**E-posta / Email:** abdullahakkayaa@icloud.com

---

## Genel Bakış / Overview
Bu proje, C# kullanılarak geliştirilmiş Spacewar oyununu içermektedir. Oyun, oyuncunun düşman uzay gemilerini yok etmeye çalıştığı aksiyon dolu bir savaş oyunudur. Farklı düşman türleri, çeşitli saldırı mekanikleri ve güçlendirme sistemleri ile zenginleştirilmiş bir oynanış sunar.

This project contains the Spacewar game developed using C#. The game is an action-packed space battle game where the player attempts to destroy enemy spaceships. Various enemy types, different attack mechanics, and a power-up system provide a dynamic gameplay experience.

---

## Özellikler / Features
- **2D Oyun Mekaniği / 2D Game Mechanics**
  - Düşman uzay gemilerine karşı savaşın. / Fight against enemy spaceships.
  - Hareket, ateş etme ve çarpışma mekanikleri. / Movement, shooting, and collision mechanics.
- **Farklı Düşman Türleri / Various Enemy Types**
  - Basit, Hızlı, Güçlü ve Patron düşmanlar. / Simple, Fast, Strong, and Boss enemies.
- **Güçlendirme Eşyaları / Power-Ups**
  - Can artışı, hız yükseltme ve daha güçlü mermi atışları. / Health boost, speed increase, and stronger bullet shots.
- **Seviye Sistemi / Level System**
  - 10 farklı seviye ile zorluk artışı. / Increasing difficulty over 10 levels.
- **Grafiksel Arayüz / Graphical Interface**
  - Windows Forms kullanılarak geliştirildi. / Developed using Windows Forms.

---

## Nasıl Oynanır? / How to Play
1. **Kontroller / Controls:**
   - Sağ (Right) Yön Tuşu: Sağa hareket ettirir. / Move right.
   - Sol (Left) Yön Tuşu: Sola hareket ettirir. / Move left.
   - Yukarı (Up) Yön Tuşu: Yukarıya hareket ettirir. / Move up.
   - Aşağı (Down) Yön Tuşu: Aşağıya hareket ettirir. / Move down.
   - Boşluk (Space) Tuşu: Mermi atar. / Shoot bullets.
2. **Oyunun Amacı / Objective:**
   - Düşmanları yok ederek hayatta kalın. / Survive by destroying enemies.
   - Seviye atlamak için tüm düşmanları temizleyin. / Clear all enemies to progress to the next level.
   - Güçlendirme eşyalarını toplayarak avantaj sağlayın. / Collect power-ups for an advantage.

---

## Teknik Detaylar / Technical Details
### Programlama Dili / Programming Language:
- **C#**

### Kullanılan Teknolojiler / Technologies Used:
- **Windows Forms** (Grafik arayüz için / For graphical interface)
- **Timer Mekanizması** (Oyun döngüsü ve düşman hareketleri için / For game loop and enemy movement)
- **Nesne Yönelimli Programlama (OOP)** (Oyun mekaniğini düzenlemek için / To organize game mechanics)

### Sınıf Yapısı / Class Structure:
- **Game:** Oyun mantığını yönetir. / Controls the game logic.
- **Spaceship:** Oyuncunun uzay gemisini temsil eder. / Represents the player's spaceship.
- **Enemy:** Düşman uzay gemilerini yönetir. / Manages enemy spaceships.
- **Bullet:** Mermileri yönetir. / Manages bullets.
- **PowerUp:** Güçlendirme eşyalarını yönetir. / Manages power-ups.

---

## Kurulum ve Çalıştırma / Installation and Setup
1. **Depoyu Klonlayın / Clone the Repository:**
   ```bash
   git clone https://github.com/yourusername/spacewar-game.git
   ```
2. **Projeyi Açın / Open the Project:**
   - Çözüm dosyasını (`.sln`) Visual Studio ile açın. / Open the solution file (`.sln`) in Visual Studio.
3. **Çalıştırın / Run the Application:**
   - Derleyin ve çalıştırın. / Build and run the project directly from Visual Studio.

---

## Lisans / License
Bu proje MIT Lisansı ile lisanslanmıştır. / This project is licensed under the MIT License.

---

## Ekran Görüntüleri / Screenshots

<img width="1186" alt="Screenshot 2024-12-19 at 01 05 42" src="https://github.com/user-attachments/assets/27efb22e-4c7f-4728-a54d-94963ee3a5d8" />

<img width="570" alt="Screenshot 2024-12-19 at 01 15 27" src="https://github.com/user-attachments/assets/9056e106-9aa5-4443-bb54-2fa65a6b3041" />

<img width="444" alt="Screenshot 2024-12-19 at 01 21 17" src="https://github.com/user-attachments/assets/a08fb9f7-0b4f-41cd-9355-3eb20766d4df" />

<img width="1183" alt="Screenshot 2024-12-19 at 01 25 54" src="https://github.com/user-attachments/assets/990040f2-884a-4ab6-919d-328e79216fde" />


## Sınıf Diyagramı / Class Diagram

![Blank diagram](https://github.com/user-attachments/assets/3272f4ca-0b3a-4e6c-84c8-6236a571ecec)


