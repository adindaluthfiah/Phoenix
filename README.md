## [PROSES INSTALASI Q-BISNIS]

Note: Pastikan Microsoft SQL Server Management Studio Ter-Install pada device user

IMPORT DATABASE:
1. Run Microsoft SSMS
2. Klik kanan pada folder Database di SMSS
3. Klik Import Data-Tier Application
4. Lalu pada setup import, bagian import setting, browse dan pilih file QBISNIS.bacpac di repository Phoenix
5. Lalu pada bagian Database Setting, atur nama database menjadi QBisnis
6. Lalu next hingga proses import data selesai

SETUP APLIKASI
1. Run file setup.exe dan tunggu hingga proses instalasi selesai


Menjalankan Program pada Visual Studio 2019

A. Instal UI
1. Buka project Q-Bisnis.sln
2. pada Solution Explorer, Kilik kanan pada project Q-Bisnis
3. Klik Manage NuGet Packages
4. Search Guna.UI2.WinForms, pilih option paling atas lalu install
5. tunggu instalasi selesai kemudian build project Q-Bisnis
6. Apabila sebelumnya telah meng install Guna.UI2.WinForms, mohon lakukan Uninstall lalu install kembali Guna.UI2.WinForms

B. Ubah ConnectionString
1. Buka QBisnis.sln 
2. Cari file app.config pada VS 2019
3. Ganti ConnectionString pada class FixedCost dan VariableCost dengan Connection String sesuai letak database QBisnis yang sudah di import sebelumnya.
Example = "Data Source=[Nama Server Laptop];Initial Catalog=Q-Bisnis;Integrated Security=True"
2. Build project tersebut dan jalankan aplikasi melalui bin -> Debug -> QBisnis.exe atau langsung jalankan di Visual Studio 2019.

