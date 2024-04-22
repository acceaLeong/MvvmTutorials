using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTutorials.ToolkitIntro.ViewModels;

public partial class MainWindowVM : ObservableRecipient, IRecipient<PropertyChangedMessage<string>>
{
    [ObservableProperty]
    private string information = "INSERT INTO Students ...";

    /// <summary>
    /// 接收来自 <see cref="StudentFormVM"/> 的属性变化的消息，并更新 <see cref="Information"/>
    /// </summary>
    public void Receive(PropertyChangedMessage<string> message)
    {
        if (message.Sender is StudentFormVM vm)
        {
            Information = vm.SqlQuery;
        } 
    }
}