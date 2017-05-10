CREATE TABLE `hospital`.`patient` (
  `patientID` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `idCardNumber` INT NOT NULL,
  `PIN` INT NOT NULL,
  `birthDate` DATETIME NOT NULL,
  PRIMARY KEY (`patientID`),
  UNIQUE INDEX `idCard_UNIQUE` (`idCardNumber` ASC),
  UNIQUE INDEX `PIN_UNIQUE` (`PIN` ASC));
  
 CREATE TABLE `hospital`.`user` (
  `userID` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `function` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC));

  CREATE TABLE `hospital`.`consultation` (
  `consultationID` INT NOT NULL AUTO_INCREMENT,
  `doctorID` INT NOT NULL,
  `patientID` INT NOT NULL,
  `details` VARCHAR(100) NOT NULL DEFAULT 'not yet seen',
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`consultationID`),
  INDEX `doctorID_PK_idx` (`doctorID` ASC),
  INDEX `patientID_FK_idx` (`patientID` ASC),
  CONSTRAINT `doctorID_FK`
    FOREIGN KEY (`doctorID`)
    REFERENCES `hospital`.`user` (`userID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `patientID_FK`
    FOREIGN KEY (`patientID`)
    REFERENCES `hospital`.`patient` (`patientID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

INSERT INTO `hospital`.`user` (`username`, `password`, `function`) VALUES ('Marian', '123', 'admin');
INSERT INTO `hospital`.`user` (`username`, `password`, `function`) VALUES ('Alex', '123', 'doctor');
INSERT INTO `hospital`.`user` (`username`, `password`, `function`) VALUES ('Anlina', '123', 'secretary');
INSERT INTO `hospital`.`user` (`username`, `password`, `function`) VALUES ('Maria', '123', 'doctor');
INSERT INTO `hospital`.`user` (`username`, `password`, `function`) VALUES ('Anda', '123', 'doctor');

INSERT INTO `hospital`.`patient` (`name`, `idCardNumber`, `PIN`, `birthDate`) VALUES ('Dorel', '12345', '31341', '1990-05-20');
INSERT INTO `hospital`.`patient` (`name`, `idCardNumber`, `PIN`, `birthDate`) VALUES ('Gabriel', '315155', '616161', '1980-03-13');
INSERT INTO `hospital`.`patient` (`name`, `idCardNumber`, `PIN`, `birthDate`) VALUES ('Bogdan', '5151', '61616', '1990-10-23');

INSERT INTO `hospital`.`consultation` (`doctorID`, `patientID`, `date`) VALUES ('2', '1', '2017-05-10');
INSERT INTO `hospital`.`consultation` (`doctorID`, `patientID`, `date`) VALUES ('4', '2', '2017-05-12');
INSERT INTO `hospital`.`consultation` (`doctorID`, `patientID`, `date`) VALUES ('5', '3', '2017-05-11');
