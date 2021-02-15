#include "Repo.h"

std::vector<Domain> Repo::read()
{

	std::vector<Domain> all;
	std::ifstream file;
	file.open(this->file_location);
	Domain object;

	while (file >> object)
		all.push_back(object);

	file.close();
	return all;
}

void Repo::write(std::vector<Domain> to_write)
{
	std::ofstream file(this->file_location);
	for (size_t i = 0; i < to_write.size(); ++i)
	{
		file << to_write[i];
	}
}
