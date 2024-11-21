using BLL.DTO;
using BLL.Enum;
using BLL.LocationBLL;
using BLL.MatchBLL;
using BLL.Models;
using BLL.NationalityBLL;
using BLL.PlayerBLL;
using BLL.TeamBLL;
using BLL.TournamentBLL;
using BLL.TournamentTypeBLL;
using BLL.UserBLL;
using BLL.Utils;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournamentDesktop_S2
{
    public partial class Admin : Form
    {
        private readonly UserLogicLayer userLogicLayer = Program.GetService<UserLogicLayer>();
        private readonly TournamentLogicLayer tournamentLogicLayer = Program.GetService<TournamentLogicLayer>();
        private readonly TeamLogicLayer teamLogicLayer = Program.GetService<TeamLogicLayer>();
        private readonly PlayerLogicLayer playerLogicLayer = Program.GetService<PlayerLogicLayer>();
        private readonly MatchLogicLayer matchLogicLayer = Program.GetService<MatchLogicLayer>();
        private readonly LocationLogicLayer locationLogicLayer = Program.GetService<LocationLogicLayer>();
        private readonly NationalityLogicLayer nationalityLogicLayer = Program.GetService<NationalityLogicLayer>();
        private readonly TournamentTypeLogicLayer tournamentTypeLogicLayer = Program.GetService<TournamentTypeLogicLayer>();

        public Admin()
        {
            InitializeComponent();
            GetTournamentView();
            GetTeamsView();
            GetPlayersView();
            GetUsersView();
            GetMatchView();
        }

        #region TOURNAMENT
        private void createTournamen_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tournamentName_tb.Text) || tournamentType_cb.Items.Count == 0 ||
                tournamentType_cb.SelectedIndex == -1 || string.IsNullOrEmpty(entryFee_tb.Text) || string.IsNullOrEmpty(prizePool_tb.Text))
            {
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TournamentType tournamentType = tournamentType_cb.SelectedItem as TournamentType;

            bool createNew = tournamentLogicLayer.AddNewTournament(CreateTournamentOBJ(-1, tournamentName_tb.Text, tournamentType.Id, tournamentType.Name,
                entryFee_tb.Text, prizePool_tb.Text, Convert.ToInt32(UtilityClass.UserId)),
                new Users(Convert.ToInt32(UtilityClass.UserId), UtilityClass.Role));

            if (!createNew)
            {
                MessageBox.Show($"Tournament with name {tournamentName_tb.Text} exists! Please, choose a new one.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            ReloadTournamentListView();
            MessageBox.Show("Tournament is successfully created!");
        }

        private void deleteTournament_btn_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                ListViewItem item = listView4.SelectedItems[0];

                int tournamentId = Convert.ToInt32(item.Tag);
                Tournament tournamentToDelete = new Tournament(tournamentId);
                tournamentLogicLayer.DeleteTournament(tournamentToDelete);

                listView4.SelectedItems[0].Remove();
                MessageBox.Show("Tournament is successfully deleted!");
            }
        }

        private void editTournament_btn_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                ListViewItem item = listView4.SelectedItems[0];

                tournamentId.Text = item.Tag.ToString();

                tournamentName_tb.Text = item.Text;
                tournamentType_cb.Text = item.SubItems[1].Text;
                entryFee_tb.Text = item.SubItems[2].Text;
                prizePool_tb.Text = item.SubItems[3].Text;
            }
        }

        private void saveEditTournament_btn_Click(object sender, EventArgs e)
        {
            if (tournamentName_tb != null && tournamentType_cb.SelectedIndex > -1 && entryFee_tb != null && prizePool_tb != null)
            {
                TournamentType tournamentType = tournamentType_cb.SelectedItem as TournamentType;

                tournamentLogicLayer.UpdateTournament(CreateTournamentOBJ(Convert.ToInt32(tournamentId.Text), tournamentName_tb.Text,
                    tournamentType.Id, tournamentType.Name, entryFee_tb.Text, prizePool_tb.Text, Convert.ToInt32(UtilityClass.UserId)));

                ReloadTournamentListView();

                MessageBox.Show("Tournament is successfully updated!");
            }
            else
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Tournament CreateTournamentOBJ(int id, string name, int tournamentTypeId, string tournamentTypeName, string entryFee, string prizePool, int userId)
        {
            return new Tournament(id, name, Convert.ToInt32(entryFee), prizePool, tournamentTypeId, tournamentTypeName, userId);
        }

        public void ReloadTournamentListView()
        {
            tournamentName_tb.Text = string.Empty;
            entryFee_tb.Text = string.Empty;
            prizePool_tb.Text = string.Empty;
            tournamentType_cb.SelectedIndex = -1;

            listView4.Items.Clear();

            GetTournamentView();
        }

        private void GetTournamentView()
        {
            // Set the view to show details.
            listView4.View = View.Details;
            // Select the item and subitems when selection is made.
            listView4.FullRowSelect = true;
            // Display grid lines.
            listView4.GridLines = true;

            listView4.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() {Text = "Tournament Name", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Tournament Type", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Entry Fee", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Prize Pool", Width = -2, TextAlign = HorizontalAlignment.Left}
            });

            var tournaments = tournamentLogicLayer.GetAllTournaments(new Users(Convert.ToInt32(UtilityClass.UserId), UtilityClass.Role));

            foreach (var tournament in tournaments)
            {
                ListViewItem item = new ListViewItem(tournament.TournamentName);
                item.Tag = tournament.Id.ToString();
                item.SubItems.Add(tournament.TournamentTypeName);
                item.SubItems.Add(tournament.EntryFee.ToString());
                item.SubItems.Add(tournament.PrizePool);

                listView4.Items.Add(item);
            }
        }

        private void tournamentType_cb_DropDown(object sender, EventArgs e)
        {
            tournamentType_cb.Items.Clear();
            tournamentType_cb.DisplayMember = "Name";
            tournamentType_cb.ValueMember = "Id";

            var tournamentsType = tournamentTypeLogicLayer.GetAllTournamentType();

            foreach (var tournamentType in tournamentsType)
            {
                tournamentType_cb.Items.Add(tournamentType);
            }
        }

        private void tournamentType_cb_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        #region Team
        private void addTeam_btn_Click(object sender, EventArgs e)
        {
            bool created = teamLogicLayer.AddNewTeam(CreateTeamOjb(-1, teamName_tb.Text));
            if (created == false)
            {
                MessageBox.Show($"Team with name {teamName_tb.Text} exists! Please, choose a new one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ReloadTeamListView();
                teamName_tb.Text = string.Empty;

                MessageBox.Show("Team is successfully created!");

            }
        }

        private void editTeam_btn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                teamLogicLayer.UpdateTeam(CreateTeamOjb(Convert.ToInt32(item.Tag), teamName_tb.Text));
                ReloadTeamListView();
                teamName_tb.Text = string.Empty;

                MessageBox.Show("Team is successfully updated!");

            }
        }

        private void deleteTeam_btn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                Team team = new Team();
                teamName_tb.Text = item.Text;
                typeof(Team).GetProperty("Id").SetValue(team, Convert.ToInt32(item.Tag));
                teamLogicLayer.DeleteTeam(team);
                listView1.SelectedItems[0].Remove();
                teamName_tb.Text = string.Empty;
                MessageBox.Show("Team is successfully deleted!");
            }
        }

        private void GetTeamsView()
        {

            // Set the view to show details.
            listView1.View = View.Details;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;

            listView1.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() {Text = "Name", Width = -2, TextAlign = HorizontalAlignment.Left}
            });

            var teams = teamLogicLayer.GetAllTeams();

            foreach (var team in teams)
            {
                ListViewItem item = new ListViewItem(team.Name);
                item.Tag = team.Id.ToString();

                listView1.Items.Add(item);
            }
        }

        public Team CreateTeamOjb(int id, string name)
        {
            return new Team(id, name);
        }

        public void ReloadTeamListView()
        {
            listView1.Items.Clear();
            GetTeamsView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                teamName_tb.Text = item.Text;
            }
        }

        #endregion

        #region Player
        private void addPlayer_btn_Click(object sender, EventArgs e)
        {
            if (playerName_tb != null && playerNationality_cb != null && playerDOB != null && playerTeam_cb.SelectedIndex > -1)
            {
                Team team = playerTeam_cb.SelectedItem as Team;
                Nationality nationality = playerNationality_cb.SelectedItem as Nationality;

                playerLogicLayer.AddNewPlayer(CreatePlayerOjb(-1, playerName_tb.Text, nationality.Id, nationality.Name, playerDOB.Value, team.Name, team.Id));
                ReloadPlayerListView();

                MessageBox.Show("Player is successfully created!");
            }
            else
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deletePlayer_btn_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];

                int playerId = Convert.ToInt32(item.Tag);
                Player playerToDelete = new Player(playerId);
                playerLogicLayer.DeletePlayer(playerToDelete);

                listView2.SelectedItems[0].Remove();

                MessageBox.Show("Player is successfully deleted!");
            }
        }

        private void editPlayer_btn_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];

                playerId.Text = item.Tag.ToString();

                playerName_tb.Text = item.Text;
                playerNationality_cb.Text = item.SubItems[1].Text;
                playerDOB.Text = item.SubItems[2].Text;
                playerTeam_cb.Text = item.SubItems[3].Text;
            }
        }

        private void saveEditPlayer_btn_Click(object sender, EventArgs e)
        {
            if (playerName_tb != null && playerNationality_cb.SelectedIndex > -1 && playerDOB != null && playerTeam_cb.SelectedIndex > -1)
            {
                Team team = playerTeam_cb.SelectedItem as Team;
                Nationality nationality = playerNationality_cb.SelectedItem as Nationality;

                playerLogicLayer.UpdatePlayer(CreatePlayerOjb(Convert.ToInt32(playerId.Text), playerName_tb.Text, nationality.Id, nationality.Name, playerDOB.Value, team.Name, team.Id));
                ReloadPlayerListView();

                MessageBox.Show("Player is successfully updated!");
            }
            else
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetPlayersView()
        {

            // Set the view to show details.
            listView2.View = View.Details;
            // Select the item and subitems when selection is made.
            listView2.FullRowSelect = true;
            // Display grid lines.
            listView2.GridLines = true;

            listView2.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() {Text = "Name", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Nationality", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Date of Birth", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Team", Width = -2, TextAlign = HorizontalAlignment.Left}
            });

            var players = playerLogicLayer.GetAllPlayers();

            foreach (var player in players)
            {
                ListViewItem item = new ListViewItem(player.Name);
                item.Tag = player.Id.ToString();
                item.SubItems.Add(player.Nationality);
                item.SubItems.Add(player.DateOfBirth.ToShortDateString());
                item.SubItems.Add(player.Team.Name);
                listView2.Items.Add(item);
            }
        }

        private void playerTeam_cb_DropDown(object sender, EventArgs e)
        {
            playerTeam_cb.Items.Clear();
            playerTeam_cb.DisplayMember = "Name";
            playerTeam_cb.ValueMember = "Id";

            var teams = teamLogicLayer.GetAllTeams();

            foreach (var team in teams)
            {
                playerTeam_cb.Items.Add(team);
            }
        }

        private void playerNationality_cb_DropDown(object sender, EventArgs e)
        {
            playerNationality_cb.Items.Clear();
            playerNationality_cb.DisplayMember = "Name";
            playerNationality_cb.ValueMember = "Id";

            var locations = nationalityLogicLayer.GetAllNationalities();

            foreach (var location in locations)
            {
                playerNationality_cb.Items.Add(location);
            }
        }

        public Player CreatePlayerOjb(int id, string name, int nationalityId, string nationality, DateTime dob, string team, int teamId)
        {
            Team playerTeam = new Team(teamId, team);
            return new Player(id, name, nationalityId, nationality, dob, playerTeam);
        }

        public void ReloadPlayerListView()
        {

            playerName_tb.Text = string.Empty;
            playerNationality_cb.SelectedIndex = -1;
            playerDOB.Text = string.Empty;
            playerTeam_cb.SelectedIndex = -1;

            listView2.Items.Clear();

            GetPlayersView();
        }
        #endregion

        #region User
        private void deleteUser_btn_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem item = listView3.SelectedItems[0];

                int userId = Convert.ToInt32(item.Tag);
                Users userToDelete = new Users(userId);
                userLogicLayer.DeleteUser(userToDelete);

                listView3.SelectedItems[0].Remove();
                MessageBox.Show("User is successfully deleted!");
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem item = listView3.SelectedItems[0];

                userId.Text = item.Tag.ToString();

                userName_tb.Text = item.Text;
                userLastName_tb.Text = item.SubItems[1].Text;
                userUsername_tb.Text = item.SubItems[2].Text;
                userPassword_tb.Text = item.SubItems[3].Text;
                userRole_cb.Text = item.SubItems[4].Text;
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (userName_tb != null && userLastName_tb != null && userUsername_tb != null && userRole_cb.SelectedIndex > -1)
            {
                Role role = (Role)userRole_cb.SelectedItem;

                var salt = "";
                var password = "";

                if (userPassword_tb == null)
                {
                    var user = userLogicLayer.GetUserById(new Users(Convert.ToInt32(userId.Text)));
                    salt = user.Salt;
                    password = user.Password;
                }
                else
                {
                    salt = PasswordHash.GenerateSalt();
                    password = PasswordHash.HashPassword(userPassword_tb.Text, salt);
                }

                userLogicLayer.UpdateUser(CreateUserOjb(Convert.ToInt32(userId.Text), userName_tb.Text, userLastName_tb.Text, userUsername_tb.Text, password, role.ToString(), salt));
                ReloadUserListView();

                MessageBox.Show("User is successfully updated!");
            }
            else
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void user_tp_Enter(object sender, EventArgs e)
        {
            userRole_cb.Items.Clear();
            userRole_cb.Items.Add(Role.ADMIN);
            userRole_cb.Items.Add(Role.USER);
        }

        private void GetUsersView()
        {
            // Set the view to show details.
            listView3.View = View.Details;
            // Select the item and subitems when selection is made.
            listView3.FullRowSelect = true;
            // Display grid lines.
            listView3.GridLines = true;

            listView3.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() {Text = "Name", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "LastName", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Username", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Password", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Role", Width = -2, TextAlign = HorizontalAlignment.Left}
            });

            var users = userLogicLayer.GetAllUsers();

            foreach (var user in users)
            {
                ListViewItem item = new ListViewItem(user.Name);
                item.Tag = user.Id.ToString();
                item.SubItems.Add(user.LastName);
                item.SubItems.Add(user.Username);
                item.SubItems.Add(new string('*', user.Password.Length));
                item.SubItems.Add(user.Role.ToString());
                listView3.Items.Add(item);
            }
        }

        public Users CreateUserOjb(int id, string name, string lastname, string username, string password, string role, string salt)
        {
            return new Users(id, name, lastname, username, password, (Role)Enum.Parse(typeof(Role), role), salt);
        }

        public void ReloadUserListView()
        {
            userName_tb.Text = string.Empty;
            userLastName_tb.Text = string.Empty;
            userUsername_tb.Text = string.Empty;
            userPassword_tb.Text = string.Empty;
            userRole_cb.SelectedIndex = -1;

            listView3.Items.Clear();

            GetUsersView();
        }
        #endregion

        #region MyAccout
        private void myAccount_tp_Enter(object sender, EventArgs e)
        {
            var user = userLogicLayer.GetUserById(new Users(Convert.ToInt32(UtilityClass.UserId)));
            myName_tb.Text = user.Name;
            myLastName_tb.Text = user.LastName;
            myUsername_tb.Text = user.Username;
            myPassword_tb.Text = user.Password;
            myRole_tb.Text = user.Role.ToString();
        }

        private void mySaveChanges_btn_Click(object sender, EventArgs e)
        {
            var salt = "";
            var password = "";

            if (myPassword_tb.Text == null)
            {
                var user = userLogicLayer.GetUserById(new Users(Convert.ToInt32(UtilityClass.UserId)));
                salt = user.Salt;
                password = user.Password;
            }
            else
            {
                salt = PasswordHash.GenerateSalt();
                password = PasswordHash.HashPassword(myPassword_tb.Text, salt);
            }

            userLogicLayer.UpdateUser(CreateUserOjb(Convert.ToInt32(UtilityClass.UserId), myName_tb.Text, myLastName_tb.Text,
                myUsername_tb.Text,password, UtilityClass.Role, salt));

            MessageBox.Show("Details are successfully updated!");
        }
        #endregion

        #region Match
        private void createMatch_btn_Click(object sender, EventArgs e)
        {
            if (dateOfMatch != null && locationMatch_cb.SelectedIndex > -1
                && tournamentMatch_cb.SelectedIndex > -1 && team1_cb.SelectedIndex > -1 && team2_cb.SelectedIndex > -1)
            {
                Tournament tournament = tournamentMatch_cb.SelectedItem as Tournament;
                Team team1 = team1_cb.SelectedItem as Team;
                Team team2 = team2_cb.SelectedItem as Team;
                Location location = locationMatch_cb.SelectedItem as Location;

                matchLogicLayer.AddNewMatch(CreateMatchOjb(-1, dateOfMatch.Value, location.Id, location.Name,
                                                           tournament.TournamentName, tournament.Id,
                                                           team1.Name, team1.Id, team2.Name, team2.Id));
                ReloadMatchListView();

                MessageBox.Show("Match is successfully created!");
            }
            else
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteMatch_btn_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count > 0)
            {
                ListViewItem item = listView5.SelectedItems[0];

                int matchId = Convert.ToInt32(item.Tag);
                Matches matchToDelete = new Matches(matchId);
                matchLogicLayer.DeleteMatch(matchToDelete);

                listView5.SelectedItems[0].Remove();
                MessageBox.Show("Match is successfully deleted!");
            }
        }

        private void editMatch_btn_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count > 0)
            {
                ListViewItem item = listView5.SelectedItems[0];

                matchId.Text = item.Tag.ToString();

                dateOfMatch.Text = item.Text;
                locationMatch_cb.Text = item.SubItems[1].Text;
                tournamentMatch_cb.Text = item.SubItems[2].Text;
                team1_cb.Text = item.SubItems[3].Text;
                team2_cb.Text = item.SubItems[4].Text;
            }
        }

        private void saveEditMatch_Click(object sender, EventArgs e)
        {
            if (dateOfMatch != null && locationMatch_cb.SelectedIndex > -1
                         && tournamentMatch_cb.SelectedIndex > -1 && team1_cb.SelectedIndex > -1 && team2_cb.SelectedIndex > -1)
            {
                Tournament tournament = tournamentMatch_cb.SelectedItem as Tournament;
                Team team1 = team1_cb.SelectedItem as Team;
                Team team2 = team2_cb.SelectedItem as Team;
                Location location = locationMatch_cb.SelectedItem as Location;

                matchLogicLayer.UpdateMatch(CreateMatchOjb(Convert.ToInt32(matchId.Text), dateOfMatch.Value, location.Id, location.Name,
                                                           tournament.TournamentName, tournament.Id,
                                                           team1.Name, team1.Id, team2.Name, team2.Id));

                ReloadMatchListView();

                MessageBox.Show("Match is successfully updated!");
            }
            else
                MessageBox.Show("Fill all the fields!", "Please !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetMatchView()
        {

            // Set the view to show details.
            listView5.View = View.Details;
            // Select the item and subitems when selection is made.
            listView5.FullRowSelect = true;
            // Display grid lines.
            listView5.GridLines = true;

            listView5.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() {Text = "Date of Match", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Location", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Tournament", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Team1", Width = -2, TextAlign = HorizontalAlignment.Left},
                new ColumnHeader() {Text = "Team2", Width = -2, TextAlign = HorizontalAlignment.Left}
            });

            var matches = matchLogicLayer.GetAllMatches();

            foreach (var match in matches)
            {
                ListViewItem item = new ListViewItem(match.DateOfMatch.ToString());
                item.Tag = match.Id.ToString();
                item.SubItems.Add(match.LocationName);
                item.SubItems.Add(match.TournamentName);
                item.SubItems.Add(match.Team1);
                item.SubItems.Add(match.Team2);
                listView5.Items.Add(item);
            }
        }

        private void tournamentMatch_cb_DropDown(object sender, EventArgs e)
        {
            tournamentMatch_cb.Items.Clear();
            tournamentMatch_cb.DisplayMember = "TournamentName";
            tournamentMatch_cb.ValueMember = "Id";

            var tournaments = tournamentLogicLayer.GetAllTournaments(new Users(Convert.ToInt32(UtilityClass.UserId), UtilityClass.Role));

            foreach (var tournament in tournaments)
            {
                tournamentMatch_cb.Items.Add(tournament);
            }
        }

        private void team1_cb_DropDown(object sender, EventArgs e)
        {
            team1_cb.Items.Clear();
            team1_cb.DisplayMember = "Name";
            team1_cb.ValueMember = "Id";

            var teams = teamLogicLayer.GetAllTeams();

            foreach (var team in teams)
            {
                team1_cb.Items.Add(team);
            }
        }

        private void team2_cb_DropDown(object sender, EventArgs e)
        {
            team2_cb.Items.Clear();
            team2_cb.DisplayMember = "Name";
            team2_cb.ValueMember = "Id";

            var teams = teamLogicLayer.GetAllTeams();

            foreach (var team in teams)
            {
                team2_cb.Items.Add(team);
            }
        }

        private void locationMatch_cb_DropDown(object sender, EventArgs e)
        {
            locationMatch_cb.Items.Clear();
            locationMatch_cb.DisplayMember = "Name";
            locationMatch_cb.ValueMember = "Id";

            var locations = locationLogicLayer.GetAllLocation();

            foreach (var location in locations)
            {
                locationMatch_cb.Items.Add(location);
            }
        }

        public Matches CreateMatchOjb(int id, DateTime date, int locationId, string locationName, string tournamentName, int tournamentId,
                                      string team1Name, int team1Id, string team2Name, int team2Id)
        {
            return new Matches(id, date, tournamentId, tournamentName, team1Id, team1Name, team2Id, team2Name, locationId, locationName);
        }

        public void ReloadMatchListView()
        {
            matchId.Text = string.Empty;
            dateOfMatch.Text = string.Empty;
            locationMatch_cb.SelectedIndex = -1;
            tournamentMatch_cb.SelectedIndex = -1;
            team1_cb.SelectedIndex = -1;
            team2_cb.SelectedIndex = -1;

            listView5.Items.Clear();

            GetMatchView();
        }
        #endregion

        private void logOut_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 logIn = new Form1();
            logIn.ShowDialog();

            UtilityClass.UserName = string.Empty;
            UtilityClass.UserId = string.Empty;
            UtilityClass.Role = string.Empty;
        }

        private void tournament_tp_Click(object sender, EventArgs e)
        {

        }
    }
}
