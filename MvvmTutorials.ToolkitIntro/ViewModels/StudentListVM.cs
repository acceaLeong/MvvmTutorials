using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using MvvmTutorials.ToolkitIntro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class StudentListVM : ObservableRecipient, IRecipient<ValueChangedMessage<Student>>
{
    public ObservableCollection<Student> Students { get; } = new();

    [ObservableProperty]
    private bool allowAddNew;

    public int StudentCount => Students?.Count ?? 0;

    public StudentListVM()
    {
        Students.CollectionChanged += (_, _) => OnPropertyChanged(nameof(StudentCount));
    }

    partial void OnAllowAddNewChanged(bool value)
    {
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<bool>(value));
    }

    public void Receive(ValueChangedMessage<Student> message)
    {
        Students.Add(message.Value);
    }
}