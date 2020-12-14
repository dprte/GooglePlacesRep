import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GooglePlaceService {
  private headers: HttpHeaders;
  private accessPointUrl: string = "https://localhost:44358/api/GooglePlace";

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ "Content-Type": "application/json; charset=utf-8" });
  }

  public getPlacesByLatLng(lat: string, lng: string): Promise<any> {
    const options = { headers: this.headers, params: { lat, lng } };
    return this.http.get(this.accessPointUrl, options)
      .toPromise()
      .then(r => {
        return r;
      })
      .catch(this.handleError);
  }

  private handleError(err) {
    console.log(err);
    return Observable.throw(err || 'Server error');
  }
}

