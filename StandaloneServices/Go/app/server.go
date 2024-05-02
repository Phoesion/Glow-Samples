package main

import (
 "fmt"
 "net/http"
)

func main() {
 http.HandleFunc("/", Handler)
 http.ListenAndServe(":8080", nil)
}

func Handler(w http.ResponseWriter, r *http.Request) {
 fmt.Fprintf(w, "Hello, World!")
}