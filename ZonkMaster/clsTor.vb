Public Class clsTor
    Public Nr As Integer
    Public Gewaehlt As Boolean
    Public Offen As Boolean
    Public Gewinn As Boolean

    Public Sub New(Nummer As Integer, IstGewinn As Boolean)
        Nr = Nummer
        Gewinn = IstGewinn
    End Sub

    Public Function Status() As String
        Return "Tor#: " & Nr &
            "    Gewählt: " & IIf(Gewaehlt, "1", "0") &
            "    Offen: " & IIf(Offen, "1", "0") &
            "    Gewinn: " & IIf(Gewinn, "1", "0")
    End Function
End Class
