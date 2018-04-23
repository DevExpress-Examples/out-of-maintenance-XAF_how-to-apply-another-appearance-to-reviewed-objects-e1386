Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace DXExample.Module
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As DevExpress.ExpressApp.IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            AddUser("Sam")
            AddUser("John")
            AddMaster("master1")
            AddMaster("master2")
            AddMaster("master3")
            AddMaster("master4")
            AddDetail("detail1")
            AddDetail("detail2")
            AddDetail("detail3")
            AddDetail("detail4")
        End Sub
        Private Sub AddUser(ByVal name As String)
            Dim user As MySimpleUser = ObjectSpace.FindObject(Of MySimpleUser)(New BinaryOperator("UserName", name))
            If user Is Nothing Then
                user = ObjectSpace.CreateObject(Of MySimpleUser)()
                user.UserName = name
                user.SetPassword("")
                user.Save()
            End If
        End Sub
        Private Sub AddMaster(ByVal name As String)
            Dim master As Master = ObjectSpace.FindObject(Of Master)(New BinaryOperator("MasterName", name))
            If master Is Nothing Then
                master = ObjectSpace.CreateObject(Of Master)()
                master.MasterName = name
                master.Save()
            End If
        End Sub
        Private Sub AddDetail(ByVal name As String)
            Dim detail As Detail = ObjectSpace.FindObject(Of Detail)(New BinaryOperator("DetailName", name))
            If detail Is Nothing Then
                detail = ObjectSpace.CreateObject(Of Detail)()
                detail.DetailName = name
                detail.Save()
            End If
        End Sub
    End Class
End Namespace
