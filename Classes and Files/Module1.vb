Imports System.Console
'Wales, England, Ireland, Scotland
'Hooker, Lock, Prop, Flanker, no.8, Scrum half, full back, fly half, centre, winger
Module Module1
    Public Class Player
        Public name, country, position As String
        Public Sub New(ByVal n As String, ByVal c As String, ByVal p As String)
            name = n
            country = c
            position = p
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

    ReadOnly Players As New List(Of Player)
    Sub Load()
        Dim currentName, currentCountry, currentPosition As String
        Dim counter As Decimal
        Dim fileToLoad As New IO.StreamReader("H:\Documents\computer science\Lower Sixth\Lions_Squad.txt")
        Try
            While Not fileToLoad.EndOfStream
                currentName = fileToLoad.ReadLine
                ' WriteLine(currentName)
                currentCountry = fileToLoad.ReadLine
                'WriteLine(currentCountry)
                currentPosition = fileToLoad.ReadLine
                'WriteLine(currentPosition)
                counter = 0
                Players.Add(New Player(currentName, currentCountry, currentPosition))
            End While
        Catch ex As Exception
            WriteLine("File not found try again")
        End Try
    End Sub
    Function CheckAnswer(position_answer As String, country_answer As String, i As Integer)
        Dim position_check, country_check As Boolean
        If position_answer = Players(i).position Then
            position_check = True
        End If

        If country_answer = Players(i).country Then
            country_check = True
        End If
        Return position_check & country_check
    End Function
    Sub Main()
        Dim random As New Random
        Dim country_check, position_check As Boolean
        Dim positions() As String = {
        "Hooker", "Lock", "Prop", "Flanker", "no.8", "Scrum half", "full back", "fly half", "centre", " winger"
        }

        Dim country() As String = {
            "Wales", "England", "Ireland", "Scotland"
        }
        Load()
        For i = 0 To Players.Count - 1
            Dim position_answer, country_answer As String
            Dim position1, position2 As Integer
            position1 = random.Next(0, 9)
            position2 = random.Next(0, 9)

            Dim country1, country2 As Integer
            country1 = random.Next(0, 3)
            country2 = random.Next(0, 3)

            WriteLine("{0} ", Players(i).name.TrimEnd)

            WriteLine(Players(i).position)
            WriteLine(positions(position1))
            WriteLine(positions(position2))
            WriteLine("What is {0}'s correct position.", Players(i).name.TrimEnd)
            position_answer = ReadLine()

            WriteLine("
")

            WriteLine(Players(i).country)
            WriteLine(country(country1))
            WriteLine(country(country2))
            WriteLine("What is {0}'s correct country.", Players(i).name.TrimEnd)
            country_answer = ReadLine()

            CheckAnswer(position_answer, country_answer, i)

            If position_check Then
                WriteLine("You were correct")
            Else
                WriteLine(Players(i).country)
            End If



            If country_check Then
                WriteLine("You were correct")
            Else
                WriteLine(Players(i).country)
            End If


            'Write("{0}, ", Players(i).country)
            ' Write("{0}", Players(i).position)
            'WriteLine("
            '")
        Next
        ReadKey()
    End Sub

End Module
