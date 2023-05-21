Imports System.Data.OleDb
Imports System.IO.File
Imports System.IO.FileStream

Public Class Form1

    Function Populate()
        da = New OleDbDataAdapter("select * From StudentInfo", Conn)
        dset = New DataSet
        da.Fill(dset, "StudentInfo")
        DBTABLE2.DataSource = dset.Tables("StudentInfo").DefaultView
        Return True
    End Function
    Private Sub ButtonNew_Click(sender As Object, e As EventArgs) Handles ButtonNew.Click
        StudentInfoBindingSource.AddNew()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Comm = New OleDbCommand
        Comm.Connection = Conn
        Comm.CommandText = "Insert into StudentInfo values('""','" & TextBoxRFID.Text & "' , '" & TextBoxName.Text & "', '" & TextBoxName.Text & "' )"
        Comm.ExecuteNonQuery()
        Populate()

    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        StudentInfoBindingSource.RemoveCurrent()
    End Sub

    Private Sub ButtonBrowseImage_Click(sender As Object, e As EventArgs) Handles ButtonBrowseImage.Click
        OpenFileDialog1.ShowDialog()
        TextBoxImage.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub TextBoxImage_TextChanged(sender As Object, e As EventArgs) Handles TextBoxImage.TextChanged
        If (System.IO.File.Exists(TextBoxImage.Text)) Then
            PictureBoxImageInput.Image = Image.FromFile(TextBoxImage.Text)
        End If
        If TextBoxImage.Text = "" Then
            PictureBoxImageInput.Hide()
        Else
            PictureBoxImageInput.Show()
        End If
    End Sub

    Dim da As New OleDbDataAdapter
    Dim dset As New DataSet
    Dim Comm As OleDbCommand
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        da = New OleDbDataAdapter("select * From StudentInfo", Conn)
        dset = New DataSet
        da.Fill(dset, "StudentInfo")
        DBTABLE2.DataSource = dset.Tables("StudentInfo").DefaultView
    End Sub


    Private Sub ButtonConnection_Click(sender As Object, e As EventArgs) Handles ButtonConnection.Click
        PictureBoxSelect.Top = ButtonConnection.Top
        PanelUserData.Visible = False
        PanelRegistrationEditUserData.Visible = False
        PanelMasterlist.Visible = False
        PanelConnection.Visible = True
    End Sub

    Private Sub ButtonUserData_Click(sender As Object, e As EventArgs) Handles ButtonUserData.Click
        PictureBoxSelect.Top = ButtonUserData.Top
        PanelConnection.Visible = False
        PanelRegistrationEditUserData.Visible = False
        PanelMasterlist.Visible = False
        PanelUserData.Visible = True
    End Sub

    Private Sub ButtonRegistration_Click(sender As Object, e As EventArgs) Handles ButtonRegistration.Click
        PictureBoxSelect.Top = ButtonRegistration.Top
        PanelConnection.Visible = False
        PanelUserData.Visible = False
        PanelMasterlist.Visible = False
        PanelRegistrationEditUserData.Visible = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBoxSelect.Top = ButtonRegistration.Top
        PanelConnection.Visible = False
        PanelUserData.Visible = False
        PanelRegistrationEditUserData.Visible = False
        PanelMasterlist.Visible = True
    End Sub

    Private Sub ButtonScanPort_Click(sender As Object, e As EventArgs) Handles ButtonScanPort.Click

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        GroupBoxImage.Location = New Point((PanelUserData.Width / 2) - (GroupBoxImage.Width / 2), GroupBoxImage.Top)
    End Sub

    Private Sub PanelRegistrationEditUserData_Paint(sender As Object, e As PaintEventArgs) Handles PanelRegistrationEditUserData.Paint
        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), PanelConnection.ClientRectangle)
    End Sub

    Private Sub PanelRegistrationEditUserData_Resize(sender As Object, e As EventArgs) Handles PanelRegistrationEditUserData.Resize
        PanelRegistrationEditUserData.Invalidate()
    End Sub

    Private Sub ButtonClearForm_Click(sender As Object, e As EventArgs) Handles ButtonClearForm.Click
        TextBoxRFID.Clear()
        TextBoxName.Clear()
        TextBoxLRN.Clear()
        TextBoxGrade.Clear()
        TextBoxDepartment.Clear()
        TextBoxImage.Clear()
    End Sub

    Private Sub DBTABLE_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DBTABLE.CellClick
        TextBoxRFID.Text = DBTABLE.Rows(e.RowIndex).Cells(1).Value.ToString
        TextBoxName.Text = DBTABLE.Rows(e.RowIndex).Cells(2).Value.ToString
        TextBoxLRN.Text = DBTABLE.Rows(e.RowIndex).Cells(3).Value.ToString
        TextBoxGrade.Text = DBTABLE.Rows(e.RowIndex).Cells(4).Value.ToString
        TextBoxDepartment.Text = DBTABLE.Rows(e.RowIndex).Cells(5).Value.ToString
        TextBoxImage.Text = DBTABLE.Rows(e.RowIndex).Cells(6).Value.ToString
    End Sub

    Private Sub DBTABLE2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DBTABLE.CellClick
        TextBoxRFID2.Text = DBTABLE2.Rows(e.RowIndex).Cells(1).Value.ToString
        TextBoxName2.Text = DBTABLE2.Rows(e.RowIndex).Cells(2).Value.ToString
        TextBoxLRN2.Text = DBTABLE2.Rows(e.RowIndex).Cells(3).Value.ToString
        TextBoxGrade2.Text = DBTABLE2.Rows(e.RowIndex).Cells(4).Value.ToString
        TextBoxDepartment2.Text = DBTABLE2.Rows(e.RowIndex).Cells(5).Value.ToString
        TextBoxImage2.Text = DBTABLE2.Rows(e.RowIndex).Cells(6).Value.ToString
    End Sub


End Class
