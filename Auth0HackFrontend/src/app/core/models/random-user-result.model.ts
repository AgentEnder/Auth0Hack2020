import { RandomUser } from './random-user.model';

export interface RandomUserResult {
    results: RandomUser[];
    info: Info;
}

export interface Info {
    seed: string;
    results: number;
    page: number;
    version: string;
}
