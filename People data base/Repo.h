#pragma once
#include "Domain.h"
class Repo
{

private:
	std::string file_location;
public:
	Repo() {};
	Repo(std::string file) { this->file_location = file; }
	std::vector<Domain> read();
	void write(std::vector<Domain> to_write);
};

