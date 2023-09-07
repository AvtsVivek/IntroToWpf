# Introduces Factory pattern in wpf.

1. Start from earlier 200240-WpfDi project.
2. To the UI Project, add a window called ChildForm.
3. Add this child form as a service.
```cs
services.AddTransient<ChildForm>();
```
4. Let the MainWindow have this childForm as a dependency.

5. Also add a button to the main window which will show the child form when clicked.

6. The problem with this is, we cant use this method to show multiple child forms.

7. So factory pattern.

8. 
