using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKOTournamentApp
{
    public partial class Form1 : Form
    {
        private List<string> playerNames = new List<string>();
        private List<Match> matches = new List<Match>();
        private int totalRounds;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPlayerName.Text))
            {
                playerNames.Add(txtPlayerName.Text);
                lstPlayers.Items.Add(txtPlayerName.Text);
                txtPlayerName.Clear();
            }
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            if (playerNames.Count < 2)
            {
                MessageBox.Show("Please add at least 2 players to create a tournament.");
                return;
            }

            // Ensure player count is 8, 16, 32, 64, etc.
            int playerCount = NextPowerOfTwo(playerNames.Count);
            while (playerNames.Count < playerCount)
            {
                playerNames.Add("Volný los");
            }

            totalRounds = (int)Math.Ceiling(Math.Log2(playerCount));
            GenerateMatches(playerCount);
            DisplayMatches();
            ProcessFreeWins();
            DisplayMatches();
        }

        private int NextPowerOfTwo(int n)
        {
            int power = 1;
            while (power < n)
            {
                power *= 2;
            }
            return power;
        }

        private void GenerateMatches(int playerCount)
        {
            matches.Clear();
            char matchLetter = 'A';

            // Generate first round matches
            int numMatches = playerCount / 2;
            for (int i = 0; i < numMatches; i++)
            {
                matches.Add(new Match(playerNames[i], playerNames[playerNames.Count - 1 - i], MatchType.Winners, matchLetter++.ToString()));
            }

            // Generate placeholders for future rounds dynamically
            for (int round = 2; round <= totalRounds; round++)
            {
                // Winners bracket matches
                for (int i = 0; i < Math.Pow(2, totalRounds - round); i++)
                {
                    matches.Add(new Match(null, null, MatchType.Winners, matchLetter++.ToString()));
                }

                // Losers bracket matches
                for (int i = 0; i < Math.Pow(2, totalRounds - round); i++)
                {
                    matches.Add(new Match(null, null, MatchType.Losers, matchLetter++.ToString()));
                }
            }

            // Final matches
            matches.Add(new Match(null, null, MatchType.WinnersFinal, matchLetter++.ToString())); // Winners Final
            matches.Add(new Match(null, null, MatchType.LosersFinal, matchLetter++.ToString())); // Losers Final
            matches.Add(new Match(null, null, MatchType.GrandFinal, matchLetter++.ToString())); // Grand Final
        }

        private void DisplayMatches()
        {
            lstMatches.Items.Clear();
            foreach (var match in matches)
            {
                lstMatches.Items.Add(match.ToString());
            }
        }

        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMatches.SelectedIndex >= 0 && lstMatches.SelectedIndex < matches.Count)
            {
                var match = matches[lstMatches.SelectedIndex];
                if (match.Player1 != null && match.Player2 != null && match.Winner == null)
                {
                    lblMatchDetails.Text = $"{match.Player1} vs {match.Player2}";
                    btnPlayer1Win.Text = match.Player1;
                    btnPlayer2Win.Text = match.Player2;
                    btnPlayer1Win.Enabled = true;
                    btnPlayer2Win.Enabled = true;
                }
                else
                {
                    lblMatchDetails.Text = "Waiting for players or already played";
                    btnPlayer1Win.Enabled = false;
                    btnPlayer2Win.Enabled = false;
                }
            }
        }

        private void btnPlayer1Win_Click(object sender, EventArgs e)
        {
            RecordResult(true);
        }

        private void btnPlayer2Win_Click(object sender, EventArgs e)
        {
            RecordResult(false);
        }

        private void RecordResult(bool player1Wins)
        {
            var match = matches[lstMatches.SelectedIndex];
            if (player1Wins)
            {
                match.Winner = match.Player1;
                match.Loser = match.Player2;
            }
            else
            {
                match.Winner = match.Player2;
                match.Loser = match.Player1;
            }

            UpdateMatches();
            ProcessFreeWins();
            DisplayMatches();
        }

        private void ProcessFreeWins()
        {
            foreach (var match in matches)
            {
                if (match.Winner == null)
                {
                    if (match.Player1 == "Volný los" && match.Player2 != null)
                    {
                        match.Winner = match.Player2;
                    }
                    else if (match.Player2 == "Volný los" && match.Player1 != null)
                    {
                        match.Winner = match.Player1;
                    }
                }
            }

            UpdateMatches();
        }

        private void UpdateMatches()
        {
            // Define how to propagate the results to the next matches
            foreach (var match in matches)
            {
                if (match.Winner != null)
                {
                    var matchIndex = matches.IndexOf(match);
                    switch (match.Type)
                    {
                        case MatchType.Winners:
                            SetNextMatchPlayers(FindNextWinnersMatch(matchIndex), match.Winner, true);
                            SetNextMatchPlayers(FindNextLosersMatch(matchIndex), match.Loser, false);
                            break;
                        case MatchType.Losers:
                            SetNextMatchPlayers(FindNextLosersMatch(matchIndex), match.Winner, true);
                            break;
                        case MatchType.WinnersFinal:
                            SetNextMatchPlayers(FindGrandFinalMatch(), match.Winner, true);
                            SetNextMatchPlayers(FindNextLosersFinalMatch(), match.Loser, true);
                            break;
                        case MatchType.LosersFinal:
                            SetNextMatchPlayers(FindGrandFinalMatch(), match.Winner, false);
                            break;
                    }
                }
            }
        }

        private int FindNextWinnersMatch(int currentIndex)
        {
            for (int i = currentIndex + 1; i < matches.Count; i++)
            {
                if (matches[i].Type == MatchType.Winners && matches[i].Player1 == null)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindNextLosersMatch(int currentIndex)
        {
            for (int i = currentIndex + 1; i < matches.Count; i++)
            {
                if (matches[i].Type == MatchType.Losers && matches[i].Player1 == null)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindNextLosersFinalMatch()
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Type == MatchType.LosersFinal && matches[i].Player1 == null)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindGrandFinalMatch()
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Type == MatchType.GrandFinal && matches[i].Player1 == null)
                {
                    return i;
                }
            }
            return -1;
        }

        private void SetNextMatchPlayers(int matchIndex, string player, bool isPlayer1)
        {
            if (matchIndex >= 0 && matchIndex < matches.Count)
            {
                var match = matches[matchIndex];
                if (isPlayer1)
                {
                    if (match.Player1 == null) match.Player1 = player;
                }
                else
                {
                    if (match.Player2 == null) match.Player2 = player;
                }
            }
        }
    }

    public enum MatchType
    {
        Winners,
        Losers,
        WinnersFinal,
        LosersFinal,
        GrandFinal
    }

    public class Match
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
        public MatchType Type { get; set; }
        public string Label { get; set; }

        public Match(string player1, string player2, MatchType type, string label)
        {
            Player1 = player1;
            Player2 = player2;
            Winner = null;
            Loser = null;
            Type = type;
            Label = label;
        }

        public override string ToString()
        {
            string player1Display = Player1 ?? $"winner match {Label}";
            string player2Display = Player2 ?? $"winner match {Label}";

            return $"{Label}: {player1Display} vs {player2Display}";
        }
    }
}
