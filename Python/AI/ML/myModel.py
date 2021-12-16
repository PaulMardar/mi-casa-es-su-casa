# -*- coding: utf-8 -*-

import torch
import torch.nn.functional as F

device = 'cpu'

class Net(torch.nn.Module):
    def __init__(self, n_feature, n_hidden, n_output):
        # we have two layers: a hidden one and an output one
        super(Net, self).__init__()
        self.hidden = torch.nn.Linear(n_feature, n_hidden)
        self.output = torch.nn.Sequential(
            torch.nn.Linear(n_feature, n_hidden).to(device),
            torch.nn.ReLU().to(device),
            torch.nn.Linear(n_hidden, n_hidden).to(device),
            torch.nn.ReLU().to(device),
            torch.nn.Linear(n_hidden, n_output).to(device)
        )
    def forward(self, x):
        # forward propagation of the signal
        # observe the refu function applied on the output of the hidden layer
        x = self.output(x)
        return x