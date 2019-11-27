Imports System.Diagnostics
Imports System.Timers

Public Class MyNewService

    Private eventID As Integer = 1

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        EventLog1 = New EventLog()

        If Not EventLog.SourceExists("MySource") Then
            EventLog.CreateEventSource("MySource", "MyNewLog")
        End If

        EventLog1.Source = "MySource"
        EventLog1.Log = "MyNewLog"

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        EventLog1.WriteEntry("In OnStart")

        Dim timer As New Timer()
        timer.Interval = 60000
        timer.Start()


    End Sub

    Public Sub onTimer(ByVal sender As Object, ByVal args As ElapsedEventArgs)

        EventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventID + 1)

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        EventLog1.WriteEntry("In OnStop.")

    End Sub

    Protected Overrides Sub onContinue()
        EventLog1.WriteEntry("In OnContinue.")

    End Sub

    Private Sub Comment()

        'This is to comment any transaction

    End Sub

End Class
