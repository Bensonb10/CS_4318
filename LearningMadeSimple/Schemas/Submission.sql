use learningmadesimple;

drop table if exists Submission;
CREATE TABLE IF NOT EXISTS Submission (
    submissionId INT AUTO_INCREMENT,
    PRIMARY KEY (submissionId),
    submission VARCHAR(50),
    date_submitted DATE,
    sectionId INT,
	FOREIGN KEY (sectionId)
		REFERENCES Section(sectionId),
    assignmentId INT,
    FOREIGN KEY (assignmentId)
        REFERENCES Assignment (assnId),
    studentId INT,
    FOREIGN KEY (studentId)
        REFERENCES Student (studentId)
);
