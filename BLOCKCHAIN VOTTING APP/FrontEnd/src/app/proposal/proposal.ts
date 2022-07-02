export interface Proposal {
    id: number;
    name: string;
    createdBy: string;
    question: string;
    finished: boolean;
    yes:string;
    no: string;
    total: string;
  }