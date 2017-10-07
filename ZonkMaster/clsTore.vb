Public Class clsTore
    Public Tore As New List(Of clsTor)

    Public Sub New()
        Dim GT As Integer = GetRandom(1, 3)
        For T = 1 To 3
            Dim tor As New clsTor(T, If(T = GT, True, False))
            Tore.Add(tor)
        Next
    End Sub

    ''' <summary>
    ''' Gewinn oder Zonk
    ''' </summary>
    ''' <returns></returns>
    Public Function Gewonnen() As Boolean
        For Each Tor As clsTor In Tore
            If Tor.Gewinn = True And Tor.Gewaehlt = True Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Ein Tor Zufällig auswählen
    ''' -darf nicht offen sein
    ''' -nicht bereits gewählt
    ''' </summary>
    ''' <returns></returns>
    Public Function Wahl()
        Dim WahlTore As New List(Of clsTor)
        For Each Tor As clsTor In Tore
            If Tor.Offen = False And Tor.Gewaehlt = False Then
                WahlTore.Add(Tor)
            End If
            If Tor.Gewaehlt = True Then Tor.Gewaehlt = False 'Es kann nur einen Geben!!
        Next
        Dim WT As Integer = GetRandom(1, WahlTore.Count)
        WahlTore.Item(WT - 1).Gewaehlt = True
        Return WahlTore.Item(WT - 1).Nr

    End Function

    ''' <summary>
    ''' Ein Tor als Tip öffnen
    ''' -darf nicht bereits gewählt sein
    ''' -darf keinen gewinn enthalten
    ''' </summary>
    ''' <returns></returns>
    Public Function Tip()
        Dim TipTore As New List(Of clsTor)
        For Each Tor As clsTor In Tore
            If Tor.Gewaehlt = False And Tor.Gewinn = False Then
                TipTore.Add(Tor)
            End If
        Next

        Dim TT As Integer = GetRandom(1, TipTore.Count)
        TipTore.Item(TT - 1).Offen = True
        Return TipTore.Item(TT - 1).Nr
    End Function

    Public Function Status() As String
        Dim log As String = ""
        For Each Tor As clsTor In Tore
            log &= Tor.Status & vbCrLf
        Next
        Return log
    End Function

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max + 1)
    End Function
End Class
