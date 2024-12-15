use master;


DROP TABLE IF EXISTS Vote;
DROP TABLE IF EXISTS Election;
DROP TABLE IF EXISTS Resident;
DROP TABLE IF EXISTS Candidate;

create table Resident(
residentID int not null primary key,
firstName varchar(20),
lastName varchar(20),
middleInitial char,
Password varchar(20),
Email varchar(20)
);

create table Candidate(
candidateID int not null primary key,
firstName varchar(20),
lastName varchar(20)
);

create table Election(
electionID int not null primary key,
electionYear int not null,
Office varchar(20),
candidateA int not null,
candidateB int,
foreign key (candidateA) references Candidate(candidateID),
foreign key (candidateB) references Candidate(candidateID)
);

create table Vote(
voteID int not null primary key,
residentID int not null,
voteYear int not null,
electionID int not null,
candidateID int not null,
foreign key (residentID) references Resident(residentID),
foreign key (electionID) references Election(electionID),
foreign key (candidateID) references Candidate(candidateID)
);


insert into Resident (residentID, firstName, lastName, middleInitial, Password, Email) values 
(1, 'Brett', 'Thieman', 'D', 'hunting', 'bdthieman@gmail.com');
insert into Resident (residentID, firstName, lastName, middleInitial, Password, Email) values 
(2, 'Maclain', 'Beach', 'P', 'engaged', 'mpbfish12@gmail.com');
insert into Resident (residentID, firstName, lastName, middleInitial, Password, Email) values 
(3, 'Austin', 'Earnest', 'M', 'pictures', 'aearenst47@gmail.com');

insert into Candidate (candidateID, firstName, lastName) values (1, 'Ryker', 'Burwell');
insert into Candidate (candidateID, firstName, lastName) values (2, 'Austin', 'Earnest');

insert into Election (electionID, electionYear, Office, candidateA, candidateB) values (1, 2024, 'Commissioner', 1, 2);

insert into Vote (voteID, residentID, voteYear, electionID, candidateID) values (1, 1, 2024, 1, 2);
insert into Vote (voteID, residentID, voteYear, electionID, candidateID) values (2, 2, 2024, 1, 2);
insert into Vote (voteID, residentID, voteYear, electionID, candidateID) values (3, 3, 2024, 1, 2);

SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE';
GO
