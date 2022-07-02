import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap } from 'rxjs';
import { Proposal } from './proposal';

@Injectable({
  providedIn: 'root'
})
export class ProposalService {


  private backendURL = 'http://localhost:5000/proposals';

  getProposals(): Observable<Proposal[]> {
    var reqHeader = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
   });
    console.log(this.http.get<Proposal[]>(this.backendURL));
    return this.http.get<Proposal[]>(this.backendURL, { headers: reqHeader })
    .pipe(
      tap(_ => this.log('fetched Referendums')),
      catchError(this.handleError<Proposal[]>('getHeroes', []))
    );
  }
  log(arg0: string): void {
    console.log(arg0);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getProposadId(id: number | string) {
  return this.getProposals().pipe(
    map((p: Proposal[]) => p.find(x => x.id === +id)!)
  );
  }


  voteYes(){
      const localKey = localStorage.getItem("hash");
  }

  voteNo()
  {
      const localKey = localStorage.getItem("hash");
  } 

  constructor(private http: HttpClient) { }

 
}
