PHONY = _make
_make: dep build bweb

PHONY += dep
dep:
	cd $(CURDIR)/web && yarn install

PHONY += build
build:
	echo 'Needs implementation'

PHONY += run
run:
	echo 'Needs implementation'

PHONY += bweb
bweb:
	cd $(CURDIR)/web && yarn run build
	mkdir -p $(CURDIR)/target/web
	cp -r $(CURDIR)/web/dist $(CURDIR)/target/web/dist