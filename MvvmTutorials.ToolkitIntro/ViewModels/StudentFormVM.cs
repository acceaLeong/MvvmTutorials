using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MvvmTutorials.ToolkitIntro.Models;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class StudentFormVM : ObservableRecipient, IRecipient<ValueChangedMessage<bool>>
{
    private bool allowAddNew;

    [ObservableProperty]
    [NotifyPropertyChangedRecipients]
    private string name;

    [ObservableProperty]
    [NotifyPropertyChangedRecipients]
    private string _class;

    [ObservableProperty]
    [NotifyPropertyChangedRecipients]
    private string phone;

    public string SqlQuery => $"INSERT INTO Students (Name, Class, Phone) VALUES ('{Name}', '{Class}', '{Phone}')";

    [RelayCommand(CanExecute = nameof(CanAddNew))]
    private void AddNew()
    {
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<Student>(new(Name, Class, Phone)));
    }

    private bool CanAddNew() => allowAddNew;

    public void Receive(ValueChangedMessage<bool> message)
    {
        allowAddNew = message.Value;

        AddNewCommand.NotifyCanExecuteChanged();
    }
}