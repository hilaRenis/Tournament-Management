namespace TournamentDesktop_S2
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            logOut_btn = new Button();
            tabControl1 = new TabControl();
            home_tp = new TabPage();
            commentHome_rtb = new RichTextBox();
            pictureBox1 = new PictureBox();
            tournament_tp = new TabPage();
            tournamentType_cb = new ComboBox();
            tournamentId = new TextBox();
            listView4 = new ListView();
            saveEditTournament_btn = new Button();
            editTournament_btn = new Button();
            createTournamen_btn = new Button();
            prizePool_tb = new TextBox();
            entryFee_tb = new TextBox();
            tournamentName_tb = new TextBox();
            prizePool_lbl = new Label();
            entryFee_lbl = new Label();
            tournamentType_lbl = new Label();
            tournamentName_lbl = new Label();
            deleteTournament_btn = new Button();
            match_tp = new TabPage();
            locationMatch_cb = new ComboBox();
            dateOfMatch = new DateTimePicker();
            listView5 = new ListView();
            matchId = new TextBox();
            saveEditMatch = new Button();
            editMatch_btn = new Button();
            createMatch_btn = new Button();
            team2_cb = new ComboBox();
            team2_lbl = new Label();
            team1_cb = new ComboBox();
            team1_lbl = new Label();
            tournamentMatch_cb = new ComboBox();
            tournamentMatch_lbl = new Label();
            location_lbl = new Label();
            date_lbl = new Label();
            deleteMatch_btn = new Button();
            team_tp = new TabPage();
            listView1 = new ListView();
            editTeam_btn = new Button();
            addTeam_btn = new Button();
            teamName_tb = new TextBox();
            teamName_lbl = new Label();
            deleteTeam_btn = new Button();
            player_tp = new TabPage();
            playerNationality_cb = new ComboBox();
            playerDOB = new DateTimePicker();
            playerId = new TextBox();
            listView2 = new ListView();
            playerTeam_lbl = new Label();
            dateOfBirth_lbl = new Label();
            nationality_lbl = new Label();
            playerTeam_cb = new ComboBox();
            playerName_lbl = new Label();
            playerName_tb = new TextBox();
            saveEditPlayer_btn = new Button();
            editPlayer_btn = new Button();
            addPlayer_btn = new Button();
            deletePlayer_btn = new Button();
            user_tp = new TabPage();
            userId = new TextBox();
            listView3 = new ListView();
            save_btn = new Button();
            edit_btn = new Button();
            userRole_cb = new ComboBox();
            userPassword_tb = new TextBox();
            userUsername_tb = new TextBox();
            userLastName_tb = new TextBox();
            userName_tb = new TextBox();
            role_lbl = new Label();
            password_lbl = new Label();
            username_lbl = new Label();
            lastname_lbl = new Label();
            name_lbl = new Label();
            deleteUser_btn = new Button();
            myAccount_tp = new TabPage();
            myRole_tb = new TextBox();
            mySaveChanges_btn = new Button();
            myRole_lbl = new Label();
            myPassword_tb = new TextBox();
            myPassword_lbl = new Label();
            myUsername_tb = new TextBox();
            myUsername_lbl = new Label();
            myLastName_tb = new TextBox();
            myLastName_lbl = new Label();
            myName_tb = new TextBox();
            myName_lbl = new Label();
            tabControl1.SuspendLayout();
            home_tp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tournament_tp.SuspendLayout();
            match_tp.SuspendLayout();
            team_tp.SuspendLayout();
            player_tp.SuspendLayout();
            user_tp.SuspendLayout();
            myAccount_tp.SuspendLayout();
            SuspendLayout();
            // 
            // logOut_btn
            // 
            logOut_btn.Location = new Point(725, 431);
            logOut_btn.Name = "logOut_btn";
            logOut_btn.Size = new Size(187, 41);
            logOut_btn.TabIndex = 3;
            logOut_btn.Text = "Log Out";
            logOut_btn.UseVisualStyleBackColor = true;
            logOut_btn.Click += logOut_btn_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(home_tp);
            tabControl1.Controls.Add(tournament_tp);
            tabControl1.Controls.Add(match_tp);
            tabControl1.Controls.Add(team_tp);
            tabControl1.Controls.Add(player_tp);
            tabControl1.Controls.Add(user_tp);
            tabControl1.Controls.Add(myAccount_tp);
            tabControl1.Location = new Point(11, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(899, 413);
            tabControl1.TabIndex = 4;
            // 
            // home_tp
            // 
            home_tp.Controls.Add(commentHome_rtb);
            home_tp.Controls.Add(pictureBox1);
            home_tp.Location = new Point(4, 29);
            home_tp.Name = "home_tp";
            home_tp.Padding = new Padding(3);
            home_tp.Size = new Size(891, 380);
            home_tp.TabIndex = 0;
            home_tp.Text = "Home";
            home_tp.UseVisualStyleBackColor = true;
            // 
            // commentHome_rtb
            // 
            commentHome_rtb.Location = new Point(16, 131);
            commentHome_rtb.Name = "commentHome_rtb";
            commentHome_rtb.ReadOnly = true;
            commentHome_rtb.Size = new Size(410, 105);
            commentHome_rtb.TabIndex = 2;
            commentHome_rtb.Text = "                         Welcome in our page!\nHere you will be able to see different matches\nbetween teams on different kind of tournaments. \nI hope you enjoy it! \n";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(432, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(453, 325);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tournament_tp
            // 
            tournament_tp.Controls.Add(tournamentType_cb);
            tournament_tp.Controls.Add(tournamentId);
            tournament_tp.Controls.Add(listView4);
            tournament_tp.Controls.Add(saveEditTournament_btn);
            tournament_tp.Controls.Add(editTournament_btn);
            tournament_tp.Controls.Add(createTournamen_btn);
            tournament_tp.Controls.Add(prizePool_tb);
            tournament_tp.Controls.Add(entryFee_tb);
            tournament_tp.Controls.Add(tournamentName_tb);
            tournament_tp.Controls.Add(prizePool_lbl);
            tournament_tp.Controls.Add(entryFee_lbl);
            tournament_tp.Controls.Add(tournamentType_lbl);
            tournament_tp.Controls.Add(tournamentName_lbl);
            tournament_tp.Controls.Add(deleteTournament_btn);
            tournament_tp.Location = new Point(4, 29);
            tournament_tp.Name = "tournament_tp";
            tournament_tp.Size = new Size(891, 380);
            tournament_tp.TabIndex = 1;
            tournament_tp.Text = "Tournament";
            tournament_tp.UseVisualStyleBackColor = true;
            tournament_tp.Click += tournament_tp_Click;
            // 
            // tournamentType_cb
            // 
            tournamentType_cb.FormattingEnabled = true;
            tournamentType_cb.Location = new Point(683, 109);
            tournamentType_cb.Name = "tournamentType_cb";
            tournamentType_cb.Size = new Size(196, 28);
            tournamentType_cb.TabIndex = 34;
            tournamentType_cb.DropDown += tournamentType_cb_DropDown;
            tournamentType_cb.Enter += tournamentType_cb_Enter;
            // 
            // tournamentId
            // 
            tournamentId.Location = new Point(683, 268);
            tournamentId.Name = "tournamentId";
            tournamentId.Size = new Size(196, 27);
            tournamentId.TabIndex = 33;
            tournamentId.Visible = false;
            // 
            // listView4
            // 
            listView4.Location = new Point(21, 24);
            listView4.Name = "listView4";
            listView4.Size = new Size(434, 284);
            listView4.TabIndex = 32;
            listView4.UseCompatibleStateImageBehavior = false;
            // 
            // saveEditTournament_btn
            // 
            saveEditTournament_btn.Location = new Point(683, 325);
            saveEditTournament_btn.Name = "saveEditTournament_btn";
            saveEditTournament_btn.Size = new Size(186, 39);
            saveEditTournament_btn.TabIndex = 30;
            saveEditTournament_btn.Text = "Save edited tournament";
            saveEditTournament_btn.UseVisualStyleBackColor = true;
            saveEditTournament_btn.Click += saveEditTournament_btn_Click;
            // 
            // editTournament_btn
            // 
            editTournament_btn.Location = new Point(475, 325);
            editTournament_btn.Name = "editTournament_btn";
            editTournament_btn.Size = new Size(186, 39);
            editTournament_btn.TabIndex = 29;
            editTournament_btn.Text = "Edit selected tournament";
            editTournament_btn.UseVisualStyleBackColor = true;
            editTournament_btn.Click += editTournament_btn_Click;
            // 
            // createTournamen_btn
            // 
            createTournamen_btn.Location = new Point(475, 268);
            createTournamen_btn.Name = "createTournamen_btn";
            createTournamen_btn.Size = new Size(186, 40);
            createTournamen_btn.TabIndex = 28;
            createTournamen_btn.Text = "Create Tournament";
            createTournamen_btn.UseVisualStyleBackColor = true;
            createTournamen_btn.Click += createTournamen_btn_Click;
            // 
            // prizePool_tb
            // 
            prizePool_tb.Location = new Point(683, 223);
            prizePool_tb.Name = "prizePool_tb";
            prizePool_tb.Size = new Size(196, 27);
            prizePool_tb.TabIndex = 27;
            // 
            // entryFee_tb
            // 
            entryFee_tb.Location = new Point(683, 168);
            entryFee_tb.Name = "entryFee_tb";
            entryFee_tb.Size = new Size(196, 27);
            entryFee_tb.TabIndex = 26;
            entryFee_tb.Text = " ";
            // 
            // tournamentName_tb
            // 
            tournamentName_tb.Location = new Point(683, 48);
            tournamentName_tb.Name = "tournamentName_tb";
            tournamentName_tb.Size = new Size(196, 27);
            tournamentName_tb.TabIndex = 24;
            // 
            // prizePool_lbl
            // 
            prizePool_lbl.AutoSize = true;
            prizePool_lbl.Location = new Point(475, 227);
            prizePool_lbl.Name = "prizePool_lbl";
            prizePool_lbl.Size = new Size(77, 20);
            prizePool_lbl.TabIndex = 23;
            prizePool_lbl.Text = "Prize Pool:";
            // 
            // entryFee_lbl
            // 
            entryFee_lbl.AutoSize = true;
            entryFee_lbl.Location = new Point(475, 171);
            entryFee_lbl.Name = "entryFee_lbl";
            entryFee_lbl.Size = new Size(72, 20);
            entryFee_lbl.TabIndex = 22;
            entryFee_lbl.Text = "Entry Fee:";
            // 
            // tournamentType_lbl
            // 
            tournamentType_lbl.AutoSize = true;
            tournamentType_lbl.Location = new Point(475, 112);
            tournamentType_lbl.Name = "tournamentType_lbl";
            tournamentType_lbl.Size = new Size(126, 20);
            tournamentType_lbl.TabIndex = 21;
            tournamentType_lbl.Text = "Tournament Type:";
            // 
            // tournamentName_lbl
            // 
            tournamentName_lbl.AutoSize = true;
            tournamentName_lbl.Location = new Point(475, 51);
            tournamentName_lbl.Name = "tournamentName_lbl";
            tournamentName_lbl.Size = new Size(135, 20);
            tournamentName_lbl.TabIndex = 20;
            tournamentName_lbl.Text = "Tournament Name:";
            // 
            // deleteTournament_btn
            // 
            deleteTournament_btn.Location = new Point(82, 325);
            deleteTournament_btn.Name = "deleteTournament_btn";
            deleteTournament_btn.Size = new Size(203, 39);
            deleteTournament_btn.TabIndex = 19;
            deleteTournament_btn.Text = "Delete selected tournament";
            deleteTournament_btn.UseVisualStyleBackColor = true;
            deleteTournament_btn.Click += deleteTournament_btn_Click;
            // 
            // match_tp
            // 
            match_tp.Controls.Add(locationMatch_cb);
            match_tp.Controls.Add(dateOfMatch);
            match_tp.Controls.Add(listView5);
            match_tp.Controls.Add(matchId);
            match_tp.Controls.Add(saveEditMatch);
            match_tp.Controls.Add(editMatch_btn);
            match_tp.Controls.Add(createMatch_btn);
            match_tp.Controls.Add(team2_cb);
            match_tp.Controls.Add(team2_lbl);
            match_tp.Controls.Add(team1_cb);
            match_tp.Controls.Add(team1_lbl);
            match_tp.Controls.Add(tournamentMatch_cb);
            match_tp.Controls.Add(tournamentMatch_lbl);
            match_tp.Controls.Add(location_lbl);
            match_tp.Controls.Add(date_lbl);
            match_tp.Controls.Add(deleteMatch_btn);
            match_tp.Location = new Point(4, 29);
            match_tp.Name = "match_tp";
            match_tp.Size = new Size(891, 380);
            match_tp.TabIndex = 2;
            match_tp.Text = "Match";
            match_tp.UseVisualStyleBackColor = true;
            // 
            // locationMatch_cb
            // 
            locationMatch_cb.FormattingEnabled = true;
            locationMatch_cb.Location = new Point(603, 69);
            locationMatch_cb.Name = "locationMatch_cb";
            locationMatch_cb.Size = new Size(266, 28);
            locationMatch_cb.TabIndex = 30;
            locationMatch_cb.DropDown += locationMatch_cb_DropDown;
            // 
            // dateOfMatch
            // 
            dateOfMatch.Location = new Point(603, 20);
            dateOfMatch.Name = "dateOfMatch";
            dateOfMatch.Size = new Size(265, 27);
            dateOfMatch.TabIndex = 28;
            // 
            // listView5
            // 
            listView5.Location = new Point(24, 27);
            listView5.Name = "listView5";
            listView5.Size = new Size(402, 295);
            listView5.TabIndex = 27;
            listView5.UseCompatibleStateImageBehavior = false;
            // 
            // matchId
            // 
            matchId.Location = new Point(713, 285);
            matchId.Name = "matchId";
            matchId.Size = new Size(156, 27);
            matchId.TabIndex = 26;
            matchId.Visible = false;
            // 
            // saveEditMatch
            // 
            saveEditMatch.Location = new Point(683, 325);
            saveEditMatch.Name = "saveEditMatch";
            saveEditMatch.Size = new Size(203, 39);
            saveEditMatch.TabIndex = 25;
            saveEditMatch.Text = "Save edited match";
            saveEditMatch.UseVisualStyleBackColor = true;
            saveEditMatch.Click += saveEditMatch_Click;
            // 
            // editMatch_btn
            // 
            editMatch_btn.Location = new Point(459, 325);
            editMatch_btn.Name = "editMatch_btn";
            editMatch_btn.Size = new Size(203, 39);
            editMatch_btn.TabIndex = 24;
            editMatch_btn.Text = "Edit selected match";
            editMatch_btn.UseVisualStyleBackColor = true;
            editMatch_btn.Click += editMatch_btn_Click;
            // 
            // createMatch_btn
            // 
            createMatch_btn.Location = new Point(459, 281);
            createMatch_btn.Name = "createMatch_btn";
            createMatch_btn.Size = new Size(203, 39);
            createMatch_btn.TabIndex = 23;
            createMatch_btn.Text = "Create Match";
            createMatch_btn.UseVisualStyleBackColor = true;
            createMatch_btn.Click += createMatch_btn_Click;
            // 
            // team2_cb
            // 
            team2_cb.FormattingEnabled = true;
            team2_cb.Location = new Point(603, 231);
            team2_cb.Name = "team2_cb";
            team2_cb.Size = new Size(266, 28);
            team2_cb.TabIndex = 22;
            team2_cb.DropDown += team2_cb_DropDown;
            // 
            // team2_lbl
            // 
            team2_lbl.AutoSize = true;
            team2_lbl.Location = new Point(462, 235);
            team2_lbl.Name = "team2_lbl";
            team2_lbl.Size = new Size(60, 20);
            team2_lbl.TabIndex = 21;
            team2_lbl.Text = "Team 2:";
            // 
            // team1_cb
            // 
            team1_cb.FormattingEnabled = true;
            team1_cb.Location = new Point(603, 173);
            team1_cb.Name = "team1_cb";
            team1_cb.Size = new Size(266, 28);
            team1_cb.TabIndex = 20;
            team1_cb.DropDown += team1_cb_DropDown;
            // 
            // team1_lbl
            // 
            team1_lbl.AutoSize = true;
            team1_lbl.Location = new Point(462, 176);
            team1_lbl.Name = "team1_lbl";
            team1_lbl.Size = new Size(64, 20);
            team1_lbl.TabIndex = 19;
            team1_lbl.Text = "Team 1: ";
            // 
            // tournamentMatch_cb
            // 
            tournamentMatch_cb.FormattingEnabled = true;
            tournamentMatch_cb.Location = new Point(603, 120);
            tournamentMatch_cb.Name = "tournamentMatch_cb";
            tournamentMatch_cb.Size = new Size(266, 28);
            tournamentMatch_cb.TabIndex = 18;
            tournamentMatch_cb.DropDown += tournamentMatch_cb_DropDown;
            // 
            // tournamentMatch_lbl
            // 
            tournamentMatch_lbl.AutoSize = true;
            tournamentMatch_lbl.Location = new Point(462, 120);
            tournamentMatch_lbl.Name = "tournamentMatch_lbl";
            tournamentMatch_lbl.Size = new Size(91, 20);
            tournamentMatch_lbl.TabIndex = 16;
            tournamentMatch_lbl.Text = "Tournament:";
            // 
            // location_lbl
            // 
            location_lbl.AutoSize = true;
            location_lbl.Location = new Point(462, 72);
            location_lbl.Name = "location_lbl";
            location_lbl.Size = new Size(69, 20);
            location_lbl.TabIndex = 15;
            location_lbl.Text = "Location:";
            // 
            // date_lbl
            // 
            date_lbl.AutoSize = true;
            date_lbl.Location = new Point(462, 21);
            date_lbl.Name = "date_lbl";
            date_lbl.Size = new Size(107, 20);
            date_lbl.TabIndex = 13;
            date_lbl.Text = "Date of Match:";
            // 
            // deleteMatch_btn
            // 
            deleteMatch_btn.Location = new Point(101, 325);
            deleteMatch_btn.Name = "deleteMatch_btn";
            deleteMatch_btn.Size = new Size(203, 39);
            deleteMatch_btn.TabIndex = 4;
            deleteMatch_btn.Text = "Delete selected match";
            deleteMatch_btn.UseVisualStyleBackColor = true;
            deleteMatch_btn.Click += deleteMatch_btn_Click;
            // 
            // team_tp
            // 
            team_tp.Controls.Add(listView1);
            team_tp.Controls.Add(editTeam_btn);
            team_tp.Controls.Add(addTeam_btn);
            team_tp.Controls.Add(teamName_tb);
            team_tp.Controls.Add(teamName_lbl);
            team_tp.Controls.Add(deleteTeam_btn);
            team_tp.Location = new Point(4, 29);
            team_tp.Name = "team_tp";
            team_tp.Size = new Size(891, 380);
            team_tp.TabIndex = 3;
            team_tp.Text = "Team";
            team_tp.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(470, 317);
            listView1.TabIndex = 19;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // editTeam_btn
            // 
            editTeam_btn.Location = new Point(603, 205);
            editTeam_btn.Name = "editTeam_btn";
            editTeam_btn.Size = new Size(203, 39);
            editTeam_btn.TabIndex = 17;
            editTeam_btn.Text = "Save Edit Team";
            editTeam_btn.UseVisualStyleBackColor = true;
            editTeam_btn.Click += editTeam_btn_Click;
            // 
            // addTeam_btn
            // 
            addTeam_btn.Location = new Point(603, 140);
            addTeam_btn.Name = "addTeam_btn";
            addTeam_btn.Size = new Size(203, 39);
            addTeam_btn.TabIndex = 16;
            addTeam_btn.Text = "Add new team ";
            addTeam_btn.UseVisualStyleBackColor = true;
            addTeam_btn.Click += addTeam_btn_Click;
            // 
            // teamName_tb
            // 
            teamName_tb.Location = new Point(603, 83);
            teamName_tb.Name = "teamName_tb";
            teamName_tb.Size = new Size(204, 27);
            teamName_tb.TabIndex = 15;
            // 
            // teamName_lbl
            // 
            teamName_lbl.AutoSize = true;
            teamName_lbl.Location = new Point(489, 85);
            teamName_lbl.Name = "teamName_lbl";
            teamName_lbl.Size = new Size(92, 20);
            teamName_lbl.TabIndex = 14;
            teamName_lbl.Text = "Team Name:";
            // 
            // deleteTeam_btn
            // 
            deleteTeam_btn.Location = new Point(603, 268);
            deleteTeam_btn.Name = "deleteTeam_btn";
            deleteTeam_btn.Size = new Size(203, 39);
            deleteTeam_btn.TabIndex = 13;
            deleteTeam_btn.Text = "Delete team";
            deleteTeam_btn.UseVisualStyleBackColor = true;
            deleteTeam_btn.Click += deleteTeam_btn_Click;
            // 
            // player_tp
            // 
            player_tp.Controls.Add(playerNationality_cb);
            player_tp.Controls.Add(playerDOB);
            player_tp.Controls.Add(playerId);
            player_tp.Controls.Add(listView2);
            player_tp.Controls.Add(playerTeam_lbl);
            player_tp.Controls.Add(dateOfBirth_lbl);
            player_tp.Controls.Add(nationality_lbl);
            player_tp.Controls.Add(playerTeam_cb);
            player_tp.Controls.Add(playerName_lbl);
            player_tp.Controls.Add(playerName_tb);
            player_tp.Controls.Add(saveEditPlayer_btn);
            player_tp.Controls.Add(editPlayer_btn);
            player_tp.Controls.Add(addPlayer_btn);
            player_tp.Controls.Add(deletePlayer_btn);
            player_tp.Location = new Point(4, 29);
            player_tp.Name = "player_tp";
            player_tp.Size = new Size(891, 380);
            player_tp.TabIndex = 4;
            player_tp.Text = "Player";
            player_tp.UseVisualStyleBackColor = true;
            // 
            // playerNationality_cb
            // 
            playerNationality_cb.FormattingEnabled = true;
            playerNationality_cb.Location = new Point(601, 79);
            playerNationality_cb.Name = "playerNationality_cb";
            playerNationality_cb.Size = new Size(266, 28);
            playerNationality_cb.TabIndex = 30;
            playerNationality_cb.DropDown += playerNationality_cb_DropDown;
            // 
            // playerDOB
            // 
            playerDOB.Location = new Point(602, 131);
            playerDOB.Name = "playerDOB";
            playerDOB.Size = new Size(265, 27);
            playerDOB.TabIndex = 29;
            // 
            // playerId
            // 
            playerId.Location = new Point(602, 237);
            playerId.Name = "playerId";
            playerId.Size = new Size(266, 27);
            playerId.TabIndex = 28;
            playerId.Visible = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(13, 16);
            listView2.Name = "listView2";
            listView2.Size = new Size(413, 304);
            listView2.TabIndex = 27;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // playerTeam_lbl
            // 
            playerTeam_lbl.AutoSize = true;
            playerTeam_lbl.Location = new Point(472, 196);
            playerTeam_lbl.Name = "playerTeam_lbl";
            playerTeam_lbl.Size = new Size(48, 20);
            playerTeam_lbl.TabIndex = 26;
            playerTeam_lbl.Text = "Team:";
            // 
            // dateOfBirth_lbl
            // 
            dateOfBirth_lbl.AutoSize = true;
            dateOfBirth_lbl.Location = new Point(472, 135);
            dateOfBirth_lbl.Name = "dateOfBirth_lbl";
            dateOfBirth_lbl.Size = new Size(97, 20);
            dateOfBirth_lbl.TabIndex = 25;
            dateOfBirth_lbl.Text = "Date of Birth:";
            // 
            // nationality_lbl
            // 
            nationality_lbl.AutoSize = true;
            nationality_lbl.Location = new Point(472, 81);
            nationality_lbl.Name = "nationality_lbl";
            nationality_lbl.Size = new Size(85, 20);
            nationality_lbl.TabIndex = 24;
            nationality_lbl.Text = "Nationality:";
            // 
            // playerTeam_cb
            // 
            playerTeam_cb.FormattingEnabled = true;
            playerTeam_cb.Location = new Point(602, 193);
            playerTeam_cb.Name = "playerTeam_cb";
            playerTeam_cb.Size = new Size(266, 28);
            playerTeam_cb.TabIndex = 18;
            playerTeam_cb.DropDown += playerTeam_cb_DropDown;
            // 
            // playerName_lbl
            // 
            playerName_lbl.AutoSize = true;
            playerName_lbl.Location = new Point(472, 19);
            playerName_lbl.Name = "playerName_lbl";
            playerName_lbl.Size = new Size(96, 20);
            playerName_lbl.TabIndex = 23;
            playerName_lbl.Text = "Player Name:";
            // 
            // playerName_tb
            // 
            playerName_tb.Location = new Point(602, 16);
            playerName_tb.Name = "playerName_tb";
            playerName_tb.Size = new Size(266, 27);
            playerName_tb.TabIndex = 22;
            // 
            // saveEditPlayer_btn
            // 
            saveEditPlayer_btn.Location = new Point(664, 325);
            saveEditPlayer_btn.Name = "saveEditPlayer_btn";
            saveEditPlayer_btn.Size = new Size(203, 39);
            saveEditPlayer_btn.TabIndex = 21;
            saveEditPlayer_btn.Text = "Save edited player";
            saveEditPlayer_btn.UseVisualStyleBackColor = true;
            saveEditPlayer_btn.Click += saveEditPlayer_btn_Click;
            // 
            // editPlayer_btn
            // 
            editPlayer_btn.Location = new Point(454, 325);
            editPlayer_btn.Name = "editPlayer_btn";
            editPlayer_btn.Size = new Size(203, 39);
            editPlayer_btn.TabIndex = 20;
            editPlayer_btn.Text = "Edit selected player";
            editPlayer_btn.UseVisualStyleBackColor = true;
            editPlayer_btn.Click += editPlayer_btn_Click;
            // 
            // addPlayer_btn
            // 
            addPlayer_btn.Location = new Point(454, 281);
            addPlayer_btn.Name = "addPlayer_btn";
            addPlayer_btn.Size = new Size(203, 39);
            addPlayer_btn.TabIndex = 19;
            addPlayer_btn.Text = "Add Player";
            addPlayer_btn.UseVisualStyleBackColor = true;
            addPlayer_btn.Click += addPlayer_btn_Click;
            // 
            // deletePlayer_btn
            // 
            deletePlayer_btn.Location = new Point(112, 325);
            deletePlayer_btn.Name = "deletePlayer_btn";
            deletePlayer_btn.Size = new Size(203, 39);
            deletePlayer_btn.TabIndex = 5;
            deletePlayer_btn.Text = "Delete selected player";
            deletePlayer_btn.UseVisualStyleBackColor = true;
            deletePlayer_btn.Click += deletePlayer_btn_Click;
            // 
            // user_tp
            // 
            user_tp.Controls.Add(userId);
            user_tp.Controls.Add(listView3);
            user_tp.Controls.Add(save_btn);
            user_tp.Controls.Add(edit_btn);
            user_tp.Controls.Add(userRole_cb);
            user_tp.Controls.Add(userPassword_tb);
            user_tp.Controls.Add(userUsername_tb);
            user_tp.Controls.Add(userLastName_tb);
            user_tp.Controls.Add(userName_tb);
            user_tp.Controls.Add(role_lbl);
            user_tp.Controls.Add(password_lbl);
            user_tp.Controls.Add(username_lbl);
            user_tp.Controls.Add(lastname_lbl);
            user_tp.Controls.Add(name_lbl);
            user_tp.Controls.Add(deleteUser_btn);
            user_tp.Location = new Point(4, 29);
            user_tp.Name = "user_tp";
            user_tp.Size = new Size(891, 380);
            user_tp.TabIndex = 5;
            user_tp.Text = "User";
            user_tp.UseVisualStyleBackColor = true;
            user_tp.Enter += user_tp_Enter;
            // 
            // userId
            // 
            userId.Location = new Point(606, 276);
            userId.Name = "userId";
            userId.Size = new Size(214, 27);
            userId.TabIndex = 31;
            userId.Visible = false;
            // 
            // listView3
            // 
            listView3.Location = new Point(16, 13);
            listView3.Name = "listView3";
            listView3.Size = new Size(463, 296);
            listView3.TabIndex = 30;
            listView3.UseCompatibleStateImageBehavior = false;
            // 
            // save_btn
            // 
            save_btn.Location = new Point(714, 327);
            save_btn.Name = "save_btn";
            save_btn.Size = new Size(165, 39);
            save_btn.TabIndex = 29;
            save_btn.Text = "Save edited user";
            save_btn.UseVisualStyleBackColor = true;
            save_btn.Click += save_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.Location = new Point(486, 327);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(165, 39);
            edit_btn.TabIndex = 28;
            edit_btn.Text = "Edit selected user";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // userRole_cb
            // 
            userRole_cb.FormattingEnabled = true;
            userRole_cb.Location = new Point(606, 223);
            userRole_cb.Name = "userRole_cb";
            userRole_cb.Size = new Size(214, 28);
            userRole_cb.TabIndex = 27;
            // 
            // userPassword_tb
            // 
            userPassword_tb.Location = new Point(606, 171);
            userPassword_tb.Name = "userPassword_tb";
            userPassword_tb.PasswordChar = '*';
            userPassword_tb.Size = new Size(214, 27);
            userPassword_tb.TabIndex = 26;
            // 
            // userUsername_tb
            // 
            userUsername_tb.Location = new Point(606, 117);
            userUsername_tb.Name = "userUsername_tb";
            userUsername_tb.Size = new Size(214, 27);
            userUsername_tb.TabIndex = 25;
            // 
            // userLastName_tb
            // 
            userLastName_tb.Location = new Point(606, 64);
            userLastName_tb.Name = "userLastName_tb";
            userLastName_tb.Size = new Size(214, 27);
            userLastName_tb.TabIndex = 24;
            // 
            // userName_tb
            // 
            userName_tb.Location = new Point(606, 13);
            userName_tb.Name = "userName_tb";
            userName_tb.Size = new Size(214, 27);
            userName_tb.TabIndex = 23;
            // 
            // role_lbl
            // 
            role_lbl.AutoSize = true;
            role_lbl.Location = new Point(486, 227);
            role_lbl.Name = "role_lbl";
            role_lbl.Size = new Size(42, 20);
            role_lbl.TabIndex = 22;
            role_lbl.Text = "Role:";
            // 
            // password_lbl
            // 
            password_lbl.AutoSize = true;
            password_lbl.Location = new Point(486, 173);
            password_lbl.Name = "password_lbl";
            password_lbl.Size = new Size(73, 20);
            password_lbl.TabIndex = 21;
            password_lbl.Text = "Password:";
            // 
            // username_lbl
            // 
            username_lbl.AutoSize = true;
            username_lbl.Location = new Point(486, 120);
            username_lbl.Name = "username_lbl";
            username_lbl.Size = new Size(78, 20);
            username_lbl.TabIndex = 20;
            username_lbl.Text = "Username:";
            // 
            // lastname_lbl
            // 
            lastname_lbl.AutoSize = true;
            lastname_lbl.Location = new Point(486, 67);
            lastname_lbl.Name = "lastname_lbl";
            lastname_lbl.Size = new Size(82, 20);
            lastname_lbl.TabIndex = 19;
            lastname_lbl.Text = "LastName: ";
            // 
            // name_lbl
            // 
            name_lbl.AutoSize = true;
            name_lbl.Location = new Point(486, 17);
            name_lbl.Name = "name_lbl";
            name_lbl.Size = new Size(56, 20);
            name_lbl.TabIndex = 18;
            name_lbl.Text = "Name: ";
            // 
            // deleteUser_btn
            // 
            deleteUser_btn.Location = new Point(89, 327);
            deleteUser_btn.Name = "deleteUser_btn";
            deleteUser_btn.Size = new Size(165, 39);
            deleteUser_btn.TabIndex = 17;
            deleteUser_btn.Text = "Delete selected user account";
            deleteUser_btn.UseVisualStyleBackColor = true;
            deleteUser_btn.Click += deleteUser_btn_Click;
            // 
            // myAccount_tp
            // 
            myAccount_tp.Controls.Add(myRole_tb);
            myAccount_tp.Controls.Add(mySaveChanges_btn);
            myAccount_tp.Controls.Add(myRole_lbl);
            myAccount_tp.Controls.Add(myPassword_tb);
            myAccount_tp.Controls.Add(myPassword_lbl);
            myAccount_tp.Controls.Add(myUsername_tb);
            myAccount_tp.Controls.Add(myUsername_lbl);
            myAccount_tp.Controls.Add(myLastName_tb);
            myAccount_tp.Controls.Add(myLastName_lbl);
            myAccount_tp.Controls.Add(myName_tb);
            myAccount_tp.Controls.Add(myName_lbl);
            myAccount_tp.Location = new Point(4, 29);
            myAccount_tp.Name = "myAccount_tp";
            myAccount_tp.Size = new Size(891, 380);
            myAccount_tp.TabIndex = 6;
            myAccount_tp.Text = "My Account";
            myAccount_tp.UseVisualStyleBackColor = true;
            myAccount_tp.Enter += myAccount_tp_Enter;
            // 
            // myRole_tb
            // 
            myRole_tb.Location = new Point(305, 300);
            myRole_tb.Name = "myRole_tb";
            myRole_tb.ReadOnly = true;
            myRole_tb.Size = new Size(204, 27);
            myRole_tb.TabIndex = 22;
            // 
            // mySaveChanges_btn
            // 
            mySaveChanges_btn.Location = new Point(619, 177);
            mySaveChanges_btn.Name = "mySaveChanges_btn";
            mySaveChanges_btn.Size = new Size(151, 29);
            mySaveChanges_btn.TabIndex = 21;
            mySaveChanges_btn.Text = "Save Changes";
            mySaveChanges_btn.UseVisualStyleBackColor = true;
            mySaveChanges_btn.Click += mySaveChanges_btn_Click;
            // 
            // myRole_lbl
            // 
            myRole_lbl.AutoSize = true;
            myRole_lbl.Location = new Point(121, 300);
            myRole_lbl.Name = "myRole_lbl";
            myRole_lbl.Size = new Size(42, 20);
            myRole_lbl.TabIndex = 19;
            myRole_lbl.Text = "Role:";
            // 
            // myPassword_tb
            // 
            myPassword_tb.Location = new Point(305, 235);
            myPassword_tb.Name = "myPassword_tb";
            myPassword_tb.PasswordChar = '*';
            myPassword_tb.Size = new Size(204, 27);
            myPassword_tb.TabIndex = 18;
            // 
            // myPassword_lbl
            // 
            myPassword_lbl.AutoSize = true;
            myPassword_lbl.Location = new Point(121, 237);
            myPassword_lbl.Name = "myPassword_lbl";
            myPassword_lbl.Size = new Size(73, 20);
            myPassword_lbl.TabIndex = 17;
            myPassword_lbl.Text = "Password:";
            // 
            // myUsername_tb
            // 
            myUsername_tb.Location = new Point(305, 179);
            myUsername_tb.Name = "myUsername_tb";
            myUsername_tb.Size = new Size(204, 27);
            myUsername_tb.TabIndex = 16;
            // 
            // myUsername_lbl
            // 
            myUsername_lbl.AutoSize = true;
            myUsername_lbl.Location = new Point(121, 181);
            myUsername_lbl.Name = "myUsername_lbl";
            myUsername_lbl.Size = new Size(81, 20);
            myUsername_lbl.TabIndex = 15;
            myUsername_lbl.Text = "UserName:";
            // 
            // myLastName_tb
            // 
            myLastName_tb.Location = new Point(305, 117);
            myLastName_tb.Name = "myLastName_tb";
            myLastName_tb.Size = new Size(204, 27);
            myLastName_tb.TabIndex = 14;
            // 
            // myLastName_lbl
            // 
            myLastName_lbl.AutoSize = true;
            myLastName_lbl.Location = new Point(121, 120);
            myLastName_lbl.Name = "myLastName_lbl";
            myLastName_lbl.Size = new Size(78, 20);
            myLastName_lbl.TabIndex = 13;
            myLastName_lbl.Text = "LastName:";
            // 
            // myName_tb
            // 
            myName_tb.Location = new Point(305, 56);
            myName_tb.Name = "myName_tb";
            myName_tb.Size = new Size(204, 27);
            myName_tb.TabIndex = 12;
            // 
            // myName_lbl
            // 
            myName_lbl.AutoSize = true;
            myName_lbl.Location = new Point(121, 59);
            myName_lbl.Name = "myName_lbl";
            myName_lbl.Size = new Size(52, 20);
            myName_lbl.TabIndex = 11;
            myName_lbl.Text = "Name:";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 484);
            Controls.Add(tabControl1);
            Controls.Add(logOut_btn);
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            tabControl1.ResumeLayout(false);
            home_tp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tournament_tp.ResumeLayout(false);
            tournament_tp.PerformLayout();
            match_tp.ResumeLayout(false);
            match_tp.PerformLayout();
            team_tp.ResumeLayout(false);
            team_tp.PerformLayout();
            player_tp.ResumeLayout(false);
            player_tp.PerformLayout();
            user_tp.ResumeLayout(false);
            user_tp.PerformLayout();
            myAccount_tp.ResumeLayout(false);
            myAccount_tp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button logOut_btn;
        private TabControl tabControl1;
        private TabPage home_tp;
        private PictureBox pictureBox1;
        private TabPage tournament_tp;
        private TextBox tournamentId;
        private ListView listView4;
        private Button saveEditTournament_btn;
        private Button editTournament_btn;
        private Button createTournamen_btn;
        private TextBox prizePool_tb;
        private TextBox entryFee_tb;
        private TextBox tournamentName_tb;
        private Label prizePool_lbl;
        private Label entryFee_lbl;
        private Label tournamentType_lbl;
        private Label tournamentName_lbl;
        private Button deleteTournament_btn;
        private TabPage match_tp;
        private DateTimePicker dateOfMatch;
        private ListView listView5;
        private TextBox matchId;
        private Button saveEditMatch;
        private Button editMatch_btn;
        private Button createMatch_btn;
        private ComboBox team2_cb;
        private Label team2_lbl;
        private ComboBox team1_cb;
        private Label team1_lbl;
        private ComboBox tournamentMatch_cb;
        private Label tournamentMatch_lbl;
        private Label location_lbl;
        private Label date_lbl;
        private Button deleteMatch_btn;
        private TabPage team_tp;
        private ListView listView1;
        private Button editTeam_btn;
        private Button addTeam_btn;
        private TextBox teamName_tb;
        private Label teamName_lbl;
        private Button deleteTeam_btn;
        private TabPage player_tp;
        private TextBox playerId;
        private ListView listView2;
        private Label playerTeam_lbl;
        private Label nationality_lbl;
        private ComboBox playerTeam_cb;
        private Label playerName_lbl;
        private TextBox playerName_tb;
        private Button saveEditPlayer_btn;
        private Button editPlayer_btn;
        private Button addPlayer_btn;
        private Button deletePlayer_btn;
        private TabPage user_tp;
        private TextBox userId;
        private ListView listView3;
        private Button save_btn;
        private Button edit_btn;
        private ComboBox userRole_cb;
        private TextBox userPassword_tb;
        private TextBox userUsername_tb;
        private TextBox userLastName_tb;
        private TextBox userName_tb;
        private Label role_lbl;
        private Label password_lbl;
        private Label username_lbl;
        private Label lastname_lbl;
        private Label name_lbl;
        private Button deleteUser_btn;
        private TabPage myAccount_tp;
        private TextBox myRole_tb;
        private Button mySaveChanges_btn;
        private Label myRole_lbl;
        private TextBox myPassword_tb;
        private Label myPassword_lbl;
        private TextBox myUsername_tb;
        private Label myUsername_lbl;
        private TextBox myLastName_tb;
        private Label myLastName_lbl;
        private TextBox myName_tb;
        private Label myName_lbl;
        private RichTextBox commentHome_rtb;
        private ComboBox tournamentType_cb;
        private DateTimePicker playerDOB;
        private Label dateOfBirth_lbl;
        private ComboBox locationMatch_cb;
        private ComboBox playerNationality_cb;
    }
}