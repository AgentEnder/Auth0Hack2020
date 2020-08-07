import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { forkJoin, Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { RandomUserResult } from '../models/random-user-result.model';
import { RandomUser } from '../models/random-user.model';

@Injectable()
export class RandomUserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getNRandomUsers(n: number): Observable<RandomUser[]>{
    return this.httpClient.get<RandomUserResult>(`https://randomuser.me/api/?results=${n}&nat=US`).pipe(
      map((x: RandomUserResult): RandomUser[] => x.results)
    );
  }
}
