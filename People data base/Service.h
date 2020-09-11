#pragma once
#include "Repo.h"
class Service
{
private:
	Repo repo;
public:
	Service() {};
	Service(Repo repo) { this->repo = repo; }
	std::vector<Domain> get_all();
};

