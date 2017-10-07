Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Text = "Optionen:" & vbCrLf &
            "W = Wählen" & vbCrLf &
            "T = Tip" & vbCrLf &
            "E = Ergebniss"
    End Sub

    Private Sub NeueTore()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Static running As Boolean = False

        If running = True Then
            running = False
            Exit Sub
        End If

        running = True

        tb_log.Text = ""
        Dim Gewonnen As Integer = 0
        Dim Verloren As Integer = 0
        Dim MaxSpiele As Integer = CInt(TextBox2.Text)
        Dim Log As String = ""
        Dim LogText As String = ""
        Dim Logging As Boolean = IIf(cb_LogAll.CheckState, True, False)

        For spiel = 1 To MaxSpiele
            If running = False Then
                Log &= "Abbruch bei Spiel# " & spiel & " von " & MaxSpiele & vbCrLf
                LogText &= Log
                Exit For
            End If
            Label2.Text = Math.Round(spiel / (MaxSpiele / 100), 2) & "%"
            Application.DoEvents()
            Log = ""
            Dim MeineTore As New clsTore
            If Logging Then
                Log = "Spiel #" & spiel & ":" & vbCrLf
                Log &= "Init: " & vbCrLf & MeineTore.Status
            End If
            If RadioButton1.Checked Or RadioButton2.Checked Or RadioButton3.Checked Then
                MeineTore.Wahl()
                If Logging Then Log &= "Wahl: " & vbCrLf & MeineTore.Status
            End If
            If RadioButton2.Checked Or RadioButton3.Checked Or RadioButton4.Checked Then
                MeineTore.Tip()
                If Logging Then Log &= "Tip: " & vbCrLf & MeineTore.Status
            End If
            If RadioButton3.Checked Or RadioButton4.Checked Then
                MeineTore.Wahl()
                If Logging Then Log &= "Wahl 2: " & vbCrLf & MeineTore.Status
            End If
            If Logging Then Log &= "Gewonnen: " & IIf(MeineTore.Gewonnen, "Ja", "Nein") & vbCrLf
            If MeineTore.Gewonnen Then
                Gewonnen = Gewonnen + 1
            Else
                Verloren = Verloren + 1
            End If
            LogText &= Log
        Next
        Log = "Ergebniss Gewonnen/Verloren: " & Gewonnen & "/" & Verloren & "  (" & Math.Round(Gewonnen / (MaxSpiele / 100), 2) & "%/" & Math.Round(Verloren / (MaxSpiele / 100), 2) & "%)" & vbCrLf &
            "------------------------------------------------------------------------"
        LogText &= Log
        tb_log.Text &= LogText
        Label2.Text = ""
        running = False
    End Sub


End Class
