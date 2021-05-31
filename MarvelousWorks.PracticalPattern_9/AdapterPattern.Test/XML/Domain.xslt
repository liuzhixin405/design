<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs">
		<xsl:output method="xml" encoding="UTF-8" indent="yes"/>
		<xsl:template match="/summary">
			<summary>
				<xsl:attribute name="xsi:noNamespaceSchemaLocation">E:/Document/Personal/paper/DomainMechanism/XSLT/DomainDataTarget.xsd</xsl:attribute>
				<xsl:for-each select="customer">
					<xsl:variable name="Vvar3_customer" select="."/>
					<xsl:for-each select="order">
						<xsl:for-each select="item">
							<xsl:variable name="Vvar5_item" select="."/>
							<xsl:for-each select="@unitPrice">
								<xsl:variable name="Vvar7_unitPrice" select="."/>
								<xsl:for-each select="$Vvar5_item/@quantity">
									<xsl:variable name="Vvar9_quantity" select="."/>
									<xsl:variable name="Vvar10_RESULTOF_multiply" select="$Vvar7_unitPrice * $Vvar9_quantity"/>
									<total>
										<xsl:for-each select="$Vvar3_customer/@name">
											<xsl:attribute name="customerName">
												<xsl:value-of select="."/>
											</xsl:attribute>
										</xsl:for-each>
										<xsl:value-of select="$Vvar10_RESULTOF_multiply"/>
									</total>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</summary>
		</xsl:template>
	</xsl:stylesheet>
