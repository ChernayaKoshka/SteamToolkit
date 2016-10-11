﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SteamToolkit;
using SteamToolkit.Community;

namespace SteamWebChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChatWindow
    {
        public readonly SteamChatHandler ChatHandler;

        public static SteamUserHandler SteamUserHandler;

        public ChatWindow(ChatEventsManager chatEventsManager, SteamChatHandler chatHandler, SteamUserHandler steamUserHandler)
        {
            chatEventsManager.ChatMessageReceived += OnChatMessage;
            SteamUserHandler = steamUserHandler;
            ChatHandler = chatHandler;
            
            Loaded += ChatWindow_Loaded;
            InitializeComponent();
        }

        void ChatWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var closeButton = new AnimatedCloseButton(EButtonStyle.Close);
            closeButton.MouseLeftButtonUp += AnimatedCloseButton_MouseLeftButtonUp;
            Grid.SetColumn(closeButton, 3);
            controlGrid.Children.Add(closeButton);

            var maximizeButton = new AnimatedCloseButton(EButtonStyle.Maximize);
            maximizeButton.MouseLeftButtonUp += AnimatedMaximizeButton_MouseLeftButtonUp;
            Grid.SetColumn(maximizeButton, 2);
            controlGrid.Children.Add(maximizeButton);

            var minimizeButton = new AnimatedCloseButton(EButtonStyle.Minimize);
            minimizeButton.MouseLeftButtonUp += AnimatedMinimizeButton_MouseLeftButtonUp;
            Grid.SetColumn(minimizeButton, 1);
            controlGrid.Children.Add(minimizeButton);
        }

        void OnChatMessage(object sender, ChatMessageArgs e)
        {
            ChatControl control = FindMatchingChatControl(IdConversions.AccountIdToUlong(e.ChatMessage.AccountIdFrom));
            if (control == null) return;
            InvokeHandleMessage(control, e.ChatMessage.Text);
        }

        ChatControl FindMatchingChatControl(ulong steamId)
        {
            foreach (TabItem item in chatTabs.Items)
            {
                object itemObject = null;
                item.Dispatcher.Invoke(() => { itemObject = item.Content; });
                var control = itemObject as ChatControl;
                if (control?.ChatterId != steamId)
                    continue;
                return control;
            }
            return null;
        }

        void InvokeAddTab(ChatUser friend, string message)
        {
            if (FindMatchingChatControl(friend.Summary.SteamId) != null) return;

            if (!chatTabs.Dispatcher.CheckAccess())
                chatTabs.Dispatcher.Invoke(() =>
                {
                    var tabItem = new TabItem { Header = friend.Summary.PersonaName };
                    var chatControl = new ChatControl(this, tabItem, ChatHandler, friend);
                    tabItem.Content = chatControl;
                    chatTabs.Items.Add(tabItem);
                    if (!string.IsNullOrEmpty(message))
                        InvokeHandleMessage(chatControl, message);
                    chatTabs.SelectedIndex = chatTabs.Items.Count - 1;
                });
            else
            {
                var tabItem = new TabItem { Header = friend.Summary.PersonaName };
                var chatControl = new ChatControl(this, tabItem, ChatHandler, friend);
                tabItem.Content = chatControl;
                chatTabs.Items.Add(tabItem);
                if (!string.IsNullOrEmpty(message))
                    InvokeHandleMessage(chatControl, message);
                chatTabs.SelectedIndex = chatTabs.Items.Count - 1;
            }
        }

        void InvokeHandleMessage(ChatControl control, string message)
        {
            if (!control.Dispatcher.CheckAccess())
                control.Dispatcher.Invoke(() => { control.HandleMessage(message); });
            else
                control.HandleMessage(message);
        }

        void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        void AnimatedCloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        void AnimatedMaximizeButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        void AnimatedMinimizeButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public void AddChatWindow(ChatUser friend, string message)
        {
            InvokeAddTab(friend, message);
        }

        public void InvokeRemoveTab(TabItem item)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => { chatTabs.Items.Remove(item); });
            }
            else
            {
                chatTabs.Items.Remove(item);
            }

            if (chatTabs.Items.Count == 0)
                Close();
        }
    }
}
