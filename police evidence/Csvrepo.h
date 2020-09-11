#pragma once
#include "FileRepo.h"
#include "Domain.h"

class Csvrepo : public FileRepo
{

public:
  std::vector<Image> load_from_file() override;
  void save_to_file(const std::vector<Image>& images) override;
  Csvrepo(const std::string& file_name) : FileRepo{file_name} {}

};