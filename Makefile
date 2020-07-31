-PHONY = _make
_make: dep build bweb

.PHONY: dep
dep:
	cd $(CURDIR)/web && yarn install

.PHONY: build
build:
	go build -v -o @a $(CURDIR)/cmd/cdnder

.PHONY: run
run:
	go run -v $(CURDIR)/cmd/cdnder

.PHONY: bweb
bweb:
	cd $(CURDIR)/web && yarn run build
	mkdir -p $(CURDIR)/target/web
	cp -r $(CURDIR)/web/dist $(CURDIR)/target/web/dist