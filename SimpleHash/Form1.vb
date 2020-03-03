Imports System.IO
Imports System.Security.Cryptography

Public Class Form1
    Private Sub Form1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            TextBox1.Text = generateHash(path)
        Next
    End Sub

    Private Sub Form1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Function generateHash(ByVal file_name As String)

        ' We declare the variable : hash
        Dim hash As SHA256 = SHA256.Create()

        Dim hashValue() As Byte
        Dim fileStream As FileStream = File.OpenRead(file_name)

        fileStream.Position = 0
        hashValue = hash.ComputeHash(fileStream)

        Dim hash_hex = PrintByteArray(hashValue)

        fileStream.Close()

        Return hash_hex
    End Function

    Public Function PrintByteArray(ByVal array() As Byte)

        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("X2")
        Next i

        Return hex_value.ToUpper
    End Function
End Class
