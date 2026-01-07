Digital Petty Cash Ledger – Console Application (C#)

This repository contains a console-based C# application developed to manage petty cash income and expenses using an in-memory ledger system.
The project follows clean OOP principles, generic programming, and a menu-driven console flow.

📌 Project: Digital Petty Cash Ledger
📝 Description

A console-based financial utility designed to:

Record Income (cash replenishments)

Record Expenses (daily small expenditures)

Calculate Total Income, Total Expenses, and Net Balance

Display a polymorphic transaction summary

Ensure compile-time type safety using generics

The system uses in-memory storage only (no database or file system).

🔧 Key Concepts Used

Object-Oriented Programming (OOP)

Abstraction & Inheritance

Polymorphism

Generics with Type Constraints

Collections (List<T>)

Static Utility Class

Menu-driven Console Interaction

Input Validation

📸 Application Output

The screenshot below shows the console execution of the application, including:

Menu options

Adding income and expenses

Calculated totals and net balance

Transaction summary display

🔄 Flowchart

The flowchart represents the logical flow of the application from user input to final output.

It explains:

Menu selection

Input handling

Ledger updates

Calculation flow

Summary generation

📐 Class Diagram

The class diagram illustrates the object-oriented structure of the system.

It highlights:

Abstract base class Transaction

Derived classes IncomeTransaction and ExpenseTransaction

Generic class Ledger<T>

Static class LedgerCalculator

Interface IReportable

▶️ How to Run the Project
dotnet run


Make sure you are inside the project root directory before running the command.

🛡️ Type Safety Guarantee

The system enforces compile-time safety using generics.

Invalid operations like adding an IncomeTransaction to an Expense ledger are prevented at compile time.

🚀 Future Enhancements

Persistent storage (File / Database)

Edit & delete transactions

Date-based filtering

ASP.NET Web API version

Unit testing support