# 📚 Library Management System

A simple Library Management System built with **ASP.NET MVC**, **Entity Framework Core (Code-First)**, and an **In-Memory Database**, following an **N-Tier Architecture**. This project allows managing authors, books, and borrowing transactions.

---

## 🔧 Tech Stack

- ASP.NET MVC (.NET 9)
- Entity Framework Core (In-Memory)
- N-Tier Architecture (Models Layer (Models) , Business Logic Layer (BLL) , Data Access Layer (DAL) and Presentation Layer(Web))
- Bootstrap for basic styling

---

## 🧠 Architecture Overview

### Layers

- **Presentation Layer:** ASP.NET MVC (Views + Controllers)
- **Business Logic Layer:** Handles all business logic (e.g., `IAuthorService`, `IBookService`, `ILibraryService`)
- **Data Access Layer:** Handles the process of Accessing data  (e.g., `IAuthorRepo`, `IBookRepo`, `ILibraryRepo`)
- **Data Layer:** EF Core Code-First with an in-memory database

### Dependency Injection

Implemented to decouple layers and follow SOLID principles using built-in ASP.NET Core DI container.

---

## ✨ Features

### ✅ Author Management
- Add, edit, delete, and list authors.
- Validation:
  - Full Name: Required, unique
  - Email: Required, unique, valid format
  - Website & Bio: Optional, Bio max 300 characters
- View list of books written by the author

### ✅ Book Management
- Add, edit, delete, and list books
- Fields:
  - Title: Required
  - Genre: Enum-based (e.g., Thriller, History, SciFi, etc.)
  - Description: Optional, max 300 characters
  - Author: Dropdown select from existing authors

### ✅ Book Library
- List of all books with current status (Available / Borrowed)
- Filtering:
  - By status
  - Borrow date
  - Return date
- Borrowing:
  - Can borrow if the book is available
  - Sets `BorrowedDate` when borrowed
  - Returns:
    - Sets `ReturnedDate`
    - Marks book as available

---

## 🧪 Sample Data

Seeded with:
- Some Authors
- Some Books

---

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/TarekFarouqq/LibraryManagmentSystem.git
   cd library-management-system
