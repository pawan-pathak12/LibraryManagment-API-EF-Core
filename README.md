# 📚 Library Management API (ASP.NET Core + EF Core)

A RESTful **Library Management API** built using **ASP.NET Core Web API** and **Entity Framework Core**.  
This project provides endpoints to manage library resources such as books, authors, and users with full **CRUD operations**.

The API is designed to demonstrate clean backend architecture, database integration using **EF Core**, and RESTful API development practices.

---

# 🚀 Features

- 📖 Manage Books (Create, Read, Update, Delete)
- 👤 Manage Authors / Users
- 🔎 Retrieve book details
- 📚 Database integration with Entity Framework Core
- 🗄 SQL Server database support
- 🔄 RESTful API endpoints
- 🧪 Easy API testing with Swagger / Postman

---

# 🛠️ Technology Stack

- **ASP.NET Core Web API**
- **C#**
- **Entity Framework Core**
- **SQL Server**
- **Swagger (API Testing)**
- **Dependency Injection**

---

# 📂 Project Structure

```
LibraryManagment-API-EF-Core
│
├── Controllers
│   ├── BooksController.cs
│   └── AuthorsController.cs
│
├── Models
│   ├── Book.cs
│   └── Author.cs
│
├── Data
│   └── LibraryDbContext.cs
│
├── Migrations
│
├── Program.cs
├── appsettings.json
└── LibraryManagment-API-EF-Core.csproj
```

---

# ⚙️ Installation & Setup

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/pawan-pathak12/LibraryManagment-API-EF-Core.git
cd LibraryManagment-API-EF-Core
```

---

### 2️⃣ Open the Project

Open the project in:

- **Visual Studio**
or
- **Visual Studio Code**

---

### 3️⃣ Configure Database

Update the **connection string** in `appsettings.json`.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=LibraryDB;Trusted_Connection=True;"
}
```

---

### 4️⃣ Apply Migrations

Run the following command in **Package Manager Console**:

```bash
Update-Database
```

or with CLI:

```bash
dotnet ef database update
```

---

### 5️⃣ Run the Project

```bash
dotnet run
```

The API will start on:

```
https://localhost:5001
```

---

# 📡 API Endpoints

## Books

| Method | Endpoint | Description |
|------|------|------|
| GET | `/api/books` | Get all books |
| GET | `/api/books/{id}` | Get book by ID |
| POST | `/api/books` | Add new book |
| PUT | `/api/books/{id}` | Update book |
| DELETE | `/api/books/{id}` | Delete book |

---

# 📷 API Documentation

Swagger UI will be available at:

```
https://localhost:{port}/swagger
```

You can test all endpoints directly from the browser.

---

# 🧠 Learning Objectives

This project demonstrates:

- Building REST APIs using **ASP.NET Core**
- Database access using **Entity Framework Core**
- Implementing **CRUD operations**
- Using **Dependency Injection**
- Managing database schema with **Migrations**

---

# 🤝 Contributing

Contributions are welcome!

1. Fork the repository  
2. Create a new branch

```
git checkout -b feature/your-feature
```

3. Commit your changes

```
git commit -m "Add new feature"
```

4. Push your branch

```
git push origin feature/your-feature
```

5. Open a Pull Request

---

# 📄 License

This project is open-source and available under the **MIT License**.

---

# 👨‍💻 Author

**Pawan Pathak**

GitHub:  
https://github.com/pawan-pathak12

---

⭐ If you like this project, consider giving it a **star** on GitHub!
