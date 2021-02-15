#pragma once

#include <string>
#include <vector>
#include <fstream>
#include <vector>
#include <stdio.h>
#include <string>
#include <sstream>

class Domain
{
private:
	std::string body_type;
	std::string name;
	std::string calitati;

public:
	std::string get_body_type() { return this->body_type; }
	std::string get_name() { return this->name; }
	std::string get_calitati() { return this->calitati; }

	void  set_body(std::string body_type) { this->body_type = body_type; }
	void set_name(std::string name) { this->name = name; }
	void set_calitati(std::string calitati) { this->calitati = calitati; }


	friend std::istream& operator>>(std::istream& instream, Domain& current);
	friend std::ostream& operator<<(std::ostream& outstream, const Domain& current);

};

