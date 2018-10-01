# BPAccounting
A simple accounting program designed to get overviews for VAT and tax ends.

## Solution setup

The solution exists out of four projects:

1. BPAccounting
2. BPAccounting.Core
3. BPAccounting.Data
4. BPAccounting.Relational

The BPAccounting main project is a WPF-based view project. It contains all classes to make a desktop UI application. The secondary project is a core project. It contains the main logic of the program and is view-independent. So in general, it should be usable for all kinds of UI projects. The third project is a .Data project. It contains all model-related classes. It should not contain logic or UI elements. The last project is meant to structure the database.

## Project setup

### BPAccounting

This project is a Dekstop WPF-application. The center point is the MainWindow.xaml. This file exists out of two big chunks. The first chunk establishes the window outer functions like a close or maximse button as well as a title area. The second area is a DrawerHost. This can be seen as canvas to put the business UI elements. 
