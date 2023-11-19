-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 08, 2016 at 12:36 PM
-- Server version: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `hrms`
--

-- --------------------------------------------------------

--
-- Table structure for table `bonustype`
--

CREATE TABLE IF NOT EXISTS `bonustype` (
`Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `country`
--

CREATE TABLE IF NOT EXISTS `country` (
`Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `country`
--

INSERT INTO `country` (`Id`, `Name`) VALUES
(2, 'United States'),
(3, 'United Kingdom'),
(4, 'Saudi Arabia'),
(5, 'Sri Lanka'),
(6, 'Australia');

-- --------------------------------------------------------

--
-- Table structure for table `deductiontype`
--

CREATE TABLE IF NOT EXISTS `deductiontype` (
`Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `designation`
--

CREATE TABLE IF NOT EXISTS `designation` (
`Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `designation`
--

INSERT INTO `designation` (`Id`, `Name`) VALUES
(1, 'Project Manager'),
(2, 'Software Developer'),
(3, 'Account Manager'),
(4, 'HR Manager');

-- --------------------------------------------------------

--
-- Table structure for table `empattendance`
--

CREATE TABLE IF NOT EXISTS `empattendance` (
`Id` int(11) NOT NULL,
  `Date` date NOT NULL,
  `EmpId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `empbonus`
--

CREATE TABLE IF NOT EXISTS `empbonus` (
`Id` int(11) NOT NULL,
  `EmpId` int(11) NOT NULL,
  `BonusType` int(11) NOT NULL,
  `DateApproved` date NOT NULL,
  `Amount` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `empdeduction`
--

CREATE TABLE IF NOT EXISTS `empdeduction` (
`Id` int(11) NOT NULL,
  `EmpId` int(11) NOT NULL,
  `DeductionType` int(11) NOT NULL,
  `DeductionDate` date NOT NULL,
  `Amount` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `empleave`
--

CREATE TABLE IF NOT EXISTS `empleave` (
`Id` int(11) NOT NULL,
  `EmpId` int(11) NOT NULL,
  `LeaveTypeId` int(11) NOT NULL,
  `DateFrom` date NOT NULL,
  `DateTo` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `emploan`
--

CREATE TABLE IF NOT EXISTS `emploan` (
`Id` int(11) NOT NULL,
  `EmpId` int(11) NOT NULL,
  `LoanDate` date NOT NULL,
  `LoanTypeId` int(11) NOT NULL,
  `Amount` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE IF NOT EXISTS `employee` (
`Id` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `MiddleName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) NOT NULL,
  `EmailAddress` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `EmpTypeId` int(11) NOT NULL,
  `DesignationId` int(11) DEFAULT NULL,
  `Country` int(11) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `Gender` varchar(10) DEFAULT NULL,
  `PassportNo` varchar(50) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`Id`, `FirstName`, `MiddleName`, `LastName`, `EmailAddress`, `IsActive`, `EmpTypeId`, `DesignationId`, `Country`, `Address`, `DateOfBirth`, `Gender`, `PassportNo`) VALUES
(1, 'Alina', NULL, 'David', 'alina.david111111@gmail.com', b'1', 1, 1, 3, NULL, NULL, 'Female', ''),
(2, 'Aliza', NULL, 'Donald', 'aliza.donald111111@gmail.com', b'0', 1, NULL, 2, NULL, NULL, 'Female', NULL),
(3, 'William', NULL, 'Hurt', 'william.hurt1111111@yahoo.com', b'1', 1, 3, 6, NULL, NULL, 'Male', NULL),
(7, 'Michael', NULL, 'Vick', 'michael.vick222222@gmail.com', b'1', 2, 4, 6, NULL, NULL, 'Male', NULL),
(24, 'John', NULL, 'William', 'john.william3333333@gmail.com', b'1', 1, 2, 6, NULL, NULL, 'Male', NULL),
(25, 'John', NULL, 'Anderson', 'john.anderson33333333@yahoo.com', b'1', 1, 1, 3, NULL, NULL, 'Male', NULL),
(26, 'Michael', NULL, 'Johnson', 'michael.johnson44444444@gmail.com', b'1', 1, 3, 6, NULL, NULL, 'Male', NULL),
(27, 'John', NULL, 'Cook', 'john.cook555555555@gmail.com', b'1', 1, 2, 6, NULL, NULL, 'Male', NULL),
(28, 'Steven', NULL, 'Smith', 'steven.smith6662334234@hotmail.com', b'1', 1, 2, 2, NULL, NULL, 'Male', NULL),
(29, 'Mark', NULL, 'Abbott', 'mark.abbott1234123434@gmail.com', b'1', 2, 2, 3, NULL, NULL, 'Male', NULL),
(30, 'Adam', NULL, 'Smith', 'adam.smith.23422343423@hotmail.com', b'1', 1, 2, 2, NULL, NULL, 'Male', NULL),
(38, 'Andra', NULL, 'Allen', 'andra.allen111111@yahoo.com', b'1', 1, 1, 2, NULL, '1990-03-25', 'Female', ''),
(41, 'Mark', NULL, 'Abbott', 'mark.abbott111111111111@gmail.com', b'1', 1, 3, 2, NULL, '1990-03-25', 'Male', '');

-- --------------------------------------------------------

--
-- Table structure for table `employeetype`
--

CREATE TABLE IF NOT EXISTS `employeetype` (
`Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employeetype`
--

INSERT INTO `employeetype` (`Id`, `Name`) VALUES
(1, 'Permanent'),
(2, 'Contractual');

-- --------------------------------------------------------

--
-- Table structure for table `empsalary`
--

CREATE TABLE IF NOT EXISTS `empsalary` (
`Id` int(11) NOT NULL,
  `EmpId` int(11) NOT NULL,
  `Month` int(11) NOT NULL,
  `Year` int(11) NOT NULL,
  `Amount` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `leavetype`
--

CREATE TABLE IF NOT EXISTS `leavetype` (
`Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `loantype`
--

CREATE TABLE IF NOT EXISTS `loantype` (
`Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bonustype`
--
ALTER TABLE `bonustype`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `country`
--
ALTER TABLE `country`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `deductiontype`
--
ALTER TABLE `deductiontype`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `designation`
--
ALTER TABLE `designation`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `empattendance`
--
ALTER TABLE `empattendance`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `empbonus`
--
ALTER TABLE `empbonus`
 ADD PRIMARY KEY (`Id`), ADD KEY `FK_EmpBonus_BonusType` (`BonusType`);

--
-- Indexes for table `empdeduction`
--
ALTER TABLE `empdeduction`
 ADD PRIMARY KEY (`Id`), ADD KEY `FK_EmpDeduction_DeductionType` (`DeductionType`), ADD KEY `FK_EmpDeduction_Employee` (`EmpId`);

--
-- Indexes for table `empleave`
--
ALTER TABLE `empleave`
 ADD PRIMARY KEY (`Id`), ADD KEY `FK_EmpLeave_Employee` (`EmpId`), ADD KEY `FK_EmpLeave_LeaveType` (`LeaveTypeId`);

--
-- Indexes for table `emploan`
--
ALTER TABLE `emploan`
 ADD PRIMARY KEY (`Id`), ADD KEY `FK_EmpLoan_Employee` (`EmpId`), ADD KEY `FK_EmpLoan_LoanType` (`LoanTypeId`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
 ADD PRIMARY KEY (`Id`), ADD KEY `FK_Employee_Country` (`Country`), ADD KEY `FK_Employee_Designation` (`DesignationId`), ADD KEY `FK_Employee_EmployeeType` (`EmpTypeId`);

--
-- Indexes for table `employeetype`
--
ALTER TABLE `employeetype`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `empsalary`
--
ALTER TABLE `empsalary`
 ADD PRIMARY KEY (`Id`), ADD KEY `FK_EmpSalary_Employee` (`EmpId`);

--
-- Indexes for table `leavetype`
--
ALTER TABLE `leavetype`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `loantype`
--
ALTER TABLE `loantype`
 ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bonustype`
--
ALTER TABLE `bonustype`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `country`
--
ALTER TABLE `country`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `deductiontype`
--
ALTER TABLE `deductiontype`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `designation`
--
ALTER TABLE `designation`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `empattendance`
--
ALTER TABLE `empattendance`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `empbonus`
--
ALTER TABLE `empbonus`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `empdeduction`
--
ALTER TABLE `empdeduction`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `empleave`
--
ALTER TABLE `empleave`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `emploan`
--
ALTER TABLE `emploan`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=42;
--
-- AUTO_INCREMENT for table `employeetype`
--
ALTER TABLE `employeetype`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `empsalary`
--
ALTER TABLE `empsalary`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `leavetype`
--
ALTER TABLE `leavetype`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `loantype`
--
ALTER TABLE `loantype`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `empattendance`
--
ALTER TABLE `empattendance`
ADD CONSTRAINT `FK_EmpAttendance_Employee` FOREIGN KEY (`Id`) REFERENCES `employee` (`Id`);

--
-- Constraints for table `empbonus`
--
ALTER TABLE `empbonus`
ADD CONSTRAINT `FK_EmpBonus_BonusType` FOREIGN KEY (`BonusType`) REFERENCES `bonustype` (`Id`),
ADD CONSTRAINT `FK_EmpBonus_Employee` FOREIGN KEY (`Id`) REFERENCES `employee` (`Id`);

--
-- Constraints for table `empdeduction`
--
ALTER TABLE `empdeduction`
ADD CONSTRAINT `FK_EmpDeduction_DeductionType` FOREIGN KEY (`DeductionType`) REFERENCES `deductiontype` (`Id`),
ADD CONSTRAINT `FK_EmpDeduction_Employee` FOREIGN KEY (`EmpId`) REFERENCES `employee` (`Id`);

--
-- Constraints for table `empleave`
--
ALTER TABLE `empleave`
ADD CONSTRAINT `FK_EmpLeave_Employee` FOREIGN KEY (`EmpId`) REFERENCES `employee` (`Id`),
ADD CONSTRAINT `FK_EmpLeave_LeaveType` FOREIGN KEY (`LeaveTypeId`) REFERENCES `leavetype` (`Id`);

--
-- Constraints for table `emploan`
--
ALTER TABLE `emploan`
ADD CONSTRAINT `FK_EmpLoan_Employee` FOREIGN KEY (`EmpId`) REFERENCES `employee` (`Id`),
ADD CONSTRAINT `FK_EmpLoan_LoanType` FOREIGN KEY (`LoanTypeId`) REFERENCES `loantype` (`Id`);

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
ADD CONSTRAINT `FK_Employee_Country` FOREIGN KEY (`Country`) REFERENCES `country` (`Id`),
ADD CONSTRAINT `FK_Employee_Designation` FOREIGN KEY (`DesignationId`) REFERENCES `designation` (`Id`),
ADD CONSTRAINT `FK_Employee_EmployeeType` FOREIGN KEY (`EmpTypeId`) REFERENCES `employeetype` (`Id`);

--
-- Constraints for table `empsalary`
--
ALTER TABLE `empsalary`
ADD CONSTRAINT `FK_EmpSalary_Employee` FOREIGN KEY (`EmpId`) REFERENCES `employee` (`Id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
