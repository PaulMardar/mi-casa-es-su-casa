#include "Service.h"

std::vector<Domain> Service::get_all()
{
	return this->repo.read();
}
